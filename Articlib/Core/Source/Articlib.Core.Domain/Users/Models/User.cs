using LittleByte.Validation;

namespace Articlib.Core.Domain.Users;

public sealed class User
{
    public Email Email { get; } // TODO: Email should only be in Identity Server.
    public Name Name { get; }

    private User(Email email, Name name)
    {
        Email = email;
        Name = name;
    }

    public static Valid<User> Create(IModelValidator<User> validator, string email, string name)
    {
        var emailDomain = new Email(email);
        var nameDomain = new Name(name);
        var user = new User(emailDomain, nameDomain);

        var result = validator.Sign(user);
        return result;
    }
}
