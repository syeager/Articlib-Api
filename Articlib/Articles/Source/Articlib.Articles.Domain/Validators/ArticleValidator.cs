using LittleByte.Domain;
using LittleByte.Validation;
using LittleByte.Validation.Validators;

namespace Articlib.Core.Domain;

public class ArticleValidator : ModelValidator<Article>
{
    public ArticleValidator()
    {
        RuleFor(a => a.Id).IsNotEmpty();
        RuleFor(a => a.PosterId).IsNotEmpty();
        RuleFor(a => a.Url).IsAbsoluteUri();
    }
}
