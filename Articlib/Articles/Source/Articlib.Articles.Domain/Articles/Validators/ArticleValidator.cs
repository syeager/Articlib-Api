using LittleByte.Domain;
using LittleByte.Validation;
using LittleByte.Validation.Validators;

namespace Articlib.Articles.Domain.Articles;

public class ArticleValidator : ModelValidator<Article>
{
    public ArticleValidator()
    {
        RuleFor(a => a.Id).IsNotEmpty();
        RuleFor(a => a.PosterId).IsNotEmpty();
        RuleFor(a => a.Url).IsAbsoluteUri();
    }
}
