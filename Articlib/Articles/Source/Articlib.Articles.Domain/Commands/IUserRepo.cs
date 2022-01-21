using LittleByte.Validation;

namespace Articlib.Core.Domain;

public interface IAddArticleCommand
{
    void Add(Valid<Article> article);
}
