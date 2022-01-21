using LittleByte.Validation;

namespace Articlib.Articles.Domain.Articles;

public interface IAddArticleCommand
{
    void Add(Valid<Article> article);
}
