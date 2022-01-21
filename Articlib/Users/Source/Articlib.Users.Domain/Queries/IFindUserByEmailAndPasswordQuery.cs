namespace Articlib.Users.Domain.Queries;

public interface IFindUserByEmailAndPasswordQuery
{
    ValueTask<User?> TryFindAsync(Email email, Password password);
}
