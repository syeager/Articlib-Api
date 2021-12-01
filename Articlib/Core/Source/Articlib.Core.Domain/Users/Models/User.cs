using LittleByte.Domain;
using LittleByte.Validation;

namespace Articlib.Core.Domain.Users;

public sealed class User
{
    public Id<User> Id { get; }
    public Email Email { get; } // TODO: Email should only be in Identity Server.
    public Name Name { get; }

    private User(Id<User> id, Email email, Name name)
    {
        Id = id;
        Email = email;
        Name = name;
    }

    public static Valid<User> Create(IModelValidator<User> validator, Id<User> id, string email, string name)
    {
        var emailDomain = new Email(email);
        var nameDomain = new Name(name);
        var user = new User(id, emailDomain, nameDomain);

        var result = validator.Sign(user);
        return result;
    }
}
