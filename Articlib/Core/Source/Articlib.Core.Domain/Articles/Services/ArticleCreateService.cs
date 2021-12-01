using LittleByte.Logging;
using LittleByte.Validation;
using Serilog;

namespace Articlib.Core.Domain.Articles;

public interface IArticleCreateService
{
    Valid<Article> Create(Uri url, Guid posterId);
}

public class ArticleCreateService : IArticleCreateService
{
    private readonly ILogger logger = Log.ForContext<ArticleCreateService>();
    private readonly IModelValidator<Article> validator;
    private readonly IArticleRepo articleRepo;

    public ArticleCreateService(IModelValidator<Article> validator, IArticleRepo articleRepo)
    {
        this.validator = validator;
        this.articleRepo = articleRepo;
    }

    public Valid<Article> Create(Uri url, Guid posterId)
    {
        var id = Guid.NewGuid();

        using var log = logger.Props()
            .Push(LK.Article.Id, id)
            .Push(LK.Article.Url, url)
            .Push(LK.Article.PosterId, posterId);

        Valid<Article> article;
        using (logger.BeginTimedOperation("Create article"))
        {
            article = Article.Create(validator, id, url, posterId);
        }

        if(article.IsSuccess)
        {
            articleRepo.Add(article);
        }

        return article;
    }
}
