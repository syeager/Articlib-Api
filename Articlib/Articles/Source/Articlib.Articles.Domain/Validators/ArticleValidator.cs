using LittleByte.Validation;

namespace Articlib.Articles.Domain;

public interface IArticleValidator : IModelValidator<Article> { }


public class ArticleValidator : ModelValidator<Article>, IArticleValidator
{
}
