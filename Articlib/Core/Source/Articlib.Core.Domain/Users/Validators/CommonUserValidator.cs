using LittleByte.Validation;

namespace Articlib.Core.Domain.Users;

public sealed class CommonUserValidator : ModelValidator<User>
{
    public CommonUserValidator()
    {
        RuleFor(u => u.Email).IsEmailAddress();
        RuleFor(u => u.Name).IsName();
    }
}