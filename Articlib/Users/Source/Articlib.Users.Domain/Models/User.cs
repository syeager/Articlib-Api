using Articlib.Users.Domain.Validators;
using LittleByte.Validation;

namespace Articlib.Users.Domain.Models;

public class User
{
    public Email Email { get; }
    public Name Name { get; }

    private User(Email email, Name name)
    {
        Email = email;
        Name = name;
    }

    public static ValidModel<User> Create(IUserValidator validator, string email, string name)
    {
        var emailDomain = new Email(email);
        var nameDomain = new Name(name);
        var user = new User(emailDomain, nameDomain);

        var result = validator.Sign(user);
        return result;
    }
}
