using LittleByte.Validation;

namespace Articlib.Core.Domain.Users;

public interface IUserRepo
{
    void Add(Valid<User> user);
}