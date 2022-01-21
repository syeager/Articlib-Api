namespace Articlib.Core.Domain.Users.Commands;

public interface IAddUserCommand
{
    Task AddAsync(Valid<User> user, Password password);
}
