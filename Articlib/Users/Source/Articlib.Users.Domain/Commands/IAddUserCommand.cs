namespace Articlib.Users.Domain.Commands;

public interface IAddUserCommand
{
    Task AddAsync(Valid<User> user, Password password);
}
