using Articlib.Core.Domain.Articles;
using Articlib.Core.Infra.Articles.Models;
using Articlib.Core.Infra.Persistence;
using LittleByte.Validation;

namespace Articlib.Core.Infra.Articles.Commands;

internal sealed class AddArticleCommand : IAddArticleCommand
{
    private readonly CoreDb coreDb;

    public AddArticleCommand(CoreDb coreDb)
    {
        this.coreDb = coreDb;
    }

    public void Add(Valid<Article> article)
    {
        var domain = article.GetModelOrThrow();
        coreDb.Add<Article, ArticleDao>(domain);
    }
}
