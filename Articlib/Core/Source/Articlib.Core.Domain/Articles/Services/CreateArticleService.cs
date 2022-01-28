using LittleByte.Core.Dates;
using LittleByte.Logging;
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
    private readonly IAddArticleCommand addArticleCommand;
    private readonly IDateService dateService;

    public ArticleCreateService(IModelValidator<Article> validator, IAddArticleCommand addArticleCommand, IDateService dateService)
    {
        this.validator = validator;
        this.addArticleCommand = addArticleCommand;
        this.dateService = dateService;
    }

    public Valid<Article> Create(Uri url, Guid posterId)
    {
        var id = Guid.NewGuid();

        using var log = logger.Props()
            .Push(LK.Article.Id, id)
            .Push(LK.Article.Url, url)
            .Push(LK.Article.PosterId, posterId);

        Valid<Article> article;
        using(logger.BeginTimedOperation("Create article"))
        {
            var now = dateService.UtcNow;
            article = Article.Create(validator, id, url, posterId, now);
        }

        if(article.IsSuccess)
        {
            addArticleCommand.Add(article);
        }

        return article;
    }
}
