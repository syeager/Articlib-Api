using LittleByte.Domain;

namespace Articlib.Users.Domain.Validators;

public sealed class CommonUserValidator : ModelValidator<User>
{
    public CommonUserValidator()
    {
        RuleFor(u => u.Id).IsNotEmpty();
        RuleFor(u => u.Email).IsEmailAddress();
        RuleFor(u => u.Name).IsName();
    }
}
