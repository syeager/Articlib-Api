using Articlib.Users.Domain.Models;
using LittleByte.Validation;

namespace Articlib.Users.Domain.Persistence;

public interface IUserRepo
{
    void Add(ValidModel<User> user);
}