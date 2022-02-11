using LittleByte.Domain;
using LittleByte.Validation.Validators;

namespace Articlib.Core.Domain.Articles;

public class ArticleValidator : ModelValidator<Article>
{
    public ArticleValidator()
    {
        RuleFor(a => a.Id).IsNotEmpty();
        RuleFor(a => a.Url).IsAbsoluteUri();
    }
}
