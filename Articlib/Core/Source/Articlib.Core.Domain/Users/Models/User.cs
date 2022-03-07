namespace Articlib.Core.Domain.Users;

public sealed class User : DomainModel<User>
{
    public Email Email { get; }
    public Name Name { get; }

    private User(Id<User> id, Email email, Name name)
        : base(id)
    {
        Email = email;
        Name = name;
    }

    public static Valid<User> Create(IModelValidator<User> validator, Id<User> id, Email email, Name name)
    {
        var user = new User(id, email, name);
        var result = validator.Sign(user);
        return result;
    }
}
