using LittleByte.Validation;

namespace Articlib.Core.Domain.Articles;

public interface IArticleRepo
{
    Article Add(Valid<Article> article);
}