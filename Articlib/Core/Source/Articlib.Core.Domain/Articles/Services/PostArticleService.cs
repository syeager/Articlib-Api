using System.Diagnostics.CodeAnalysis;
using Articlib.Core.Domain.Articles.Exceptions;
using Articlib.Core.Domain.Articles.Queries;
using Articlib.Core.Domain.Users;

namespace Articlib.Core.Domain.Articles.Services;

public interface IPostArticleService
{
    Task<Valid<Article>> FromUserAsync(Id<User> userId, Uri url);
}

public sealed class PostArticleService : IPostArticleService
{
    private readonly ILogger logger = Log.ForContext<PostArticleService>();
    private readonly IModelValidator<Article> validator;
    private readonly IAddArticleCommand addArticleCommand;
    private readonly IFindArticleByUrlQuery findArticleByUrlQuery;
    private readonly IDoesArticlePostExistQuery doesArticlePostExistQuery;
    private readonly IDateService dateService;
    private readonly IAddArticlePostCommand addArticlePostCommand;

    public PostArticleService(
        IModelValidator<Article> validator,
        IAddArticleCommand addArticleCommand,
        IDateService dateService,
        IFindArticleByUrlQuery findArticleByUrlQuery,
        IDoesArticlePostExistQuery doesArticlePostExistQuery,
        IAddArticlePostCommand addArticlePostCommand)
    {
        this.validator = validator;
        this.addArticleCommand = addArticleCommand;
        this.dateService = dateService;
        this.findArticleByUrlQuery = findArticleByUrlQuery;
        this.doesArticlePostExistQuery = doesArticlePostExistQuery;
        this.addArticlePostCommand = addArticlePostCommand;
    }

    public async Task<Valid<Article>> FromUserAsync(Id<User> userId, Uri url)
    {
        using var log = logger.Props()
            .DiagnosticPush(LK.Article.PosterId, userId);

        var now = dateService.UtcNow;

        var article = await FindOrCreateArticleAsync(url, now);
        await CreateArticlePostAsync(userId, article.GetModelOrThrow(), now);

        return article;
    }

    private async Task<Valid<Article>> FindOrCreateArticleAsync(Uri url, DateTime postDate)
    {
        var existingArticle = await findArticleByUrlQuery.FindAsync(url);
        var validArticle = existingArticle is null
            ? CreateArticle(url, postDate)
            : AddNewPost(postDate, existingArticle);

        return validArticle;
    }

    private Valid<Article> CreateArticle(Uri url, DateTime postDate)
    {
        Valid<Article> validArticle;
        var id = new Id<Article>();

        Logs.DiagnosticContext.Set(LK.Article.Id, id);
        logger.Information("Posting new article");

        validArticle = Article.Create(validator, id, url, 0, 1, postDate);
        addArticleCommand.Add(validArticle);
        return validArticle;
    }

    private Valid<Article> AddNewPost(DateTime postDate, [DisallowNull] Valid<Article>? existingArticle)
    {
        Valid<Article> validArticle;
        validArticle = existingArticle.Value;
        var article = validArticle.GetModelOrThrow();

        Logs.DiagnosticContext.Set(LK.Article.Id, article.Id);
        logger.Information("Already posted article found");

        article.AddPost(postDate);
        return validArticle;
    }

    private async Task CreateArticlePostAsync(Id<User> userId, Article article, DateTime postDate)
    {
        var hasUserAlreadyPosted = await doesArticlePostExistQuery.SearchAsync(userId, article.Id);
        if(hasUserAlreadyPosted)
        {
            throw new UserAlreadyPostedArticleException(userId, article.Id);
        }

        logger.Information("New article post");
        var articlePost = new ArticlePost(userId, article.Id, postDate);
        addArticlePostCommand.Add(articlePost);
    }
}
