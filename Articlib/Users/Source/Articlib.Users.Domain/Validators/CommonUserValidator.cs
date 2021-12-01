using Articlib.Users.Domain.Models;
using LittleByte.Validation;

namespace Articlib.Users.Domain.Validators;

public interface IUserValidator : IModelValidator<User> { }

internal sealed class CommonUserValidator : ModelValidator<User>, IUserValidator
{
    public CommonUserValidator()
    {
        RuleFor(u => u.Email).IsEmailAddress();
        RuleFor(u => u.Name).IsName();
    }
}