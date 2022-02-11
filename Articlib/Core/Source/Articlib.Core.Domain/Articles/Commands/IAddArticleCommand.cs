namespace Articlib.Core.Domain.Articles;

public interface IAddArticleCommand
{
    void Add(Valid<Article> article);
}
