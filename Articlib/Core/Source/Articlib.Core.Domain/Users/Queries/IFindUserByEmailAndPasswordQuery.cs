namespace Articlib.Core.Domain.Users.Queries;

public interface IFindUserByEmailAndPasswordQuery
{
    ValueTask<User?> TryFindAsync(Email email, Password password);
}
