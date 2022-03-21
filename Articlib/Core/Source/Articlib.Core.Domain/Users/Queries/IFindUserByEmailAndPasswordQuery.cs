namespace Articlib.Core.Domain.Users.Queries;

public interface IFindUserByEmailAndPasswordQuery
{
    ValueTask<Valid<User>?> TryFindAsync(Email email, Password password);
}
