using Articlib.Core.Domain.Articles.Exceptions;
using Articlib.Core.Domain.Articles.Queries;
using Articlib.Core.Domain.Users;
using LittleByte.Core.Dates;
using LittleByte.Domain;
using LittleByte.Logging;
using Serilog;

namespace Articlib.Core.Domain.Articles;

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

        var article = await FindOrCreateArticleAsync(url);
        await CreateArticlePostAsync(userId, article.GetModelOrThrow());

        return article;
    }

    private async Task<Valid<Article>> FindOrCreateArticleAsync(Uri url)
    {
        var article = await findArticleByUrlQuery.FindAsync(url);
        if(article is null)
        {
            var id = Guid.NewGuid();
            Logs.DiagnosticContext.Set(LK.Article.Id, id);
            logger.Information("Posting new article");

            var newArticle = Article.Create(validator, id, url, 0);
            addArticleCommand.Add(newArticle);
            article = newArticle;
        }
        else
        {
            var id = article.Value.GetModelOrThrow().Id;
            Logs.DiagnosticContext.Set(LK.Article.Id, id);
            logger.Information("Already posted article found");
        }

        return article.Value;
    }

    private async Task CreateArticlePostAsync(Id<User> userId, Article article)
    {
        var hasUserAlreadyPosted = await doesArticlePostExistQuery.SearchAsync(userId, article.Id);
        if(hasUserAlreadyPosted)
        {
            throw new UserAlreadyPostedArticleException(userId, article.Id);
        }

        logger.Information("New article post");
        var now = dateService.UtcNow;
        var articlePost = new ArticlePost(userId, article.Id, now);
        addArticlePostCommand.Add(articlePost);
    }
}
