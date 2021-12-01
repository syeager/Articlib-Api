using Articlib.Core.Domain.Users;
using AutoMapper;
using LittleByte.Infra;
using LittleByte.Validation;

namespace Articlib.Core.Infra.Users;

public interface IUserReadRepo : IRepo
{}

public interface IUserWriteRepo : IUserReadRepo, IUserRepo
{
}

[UsedImplicitly]
internal class UserRepo : Repo<UserDb>, IUserWriteRepo
{
    public UserRepo(UserDb dbContext, IMapper mapper)
        : base(dbContext, mapper)
    {
    }

    public void Add(Valid<User> user)
    {
        var dao = mapper.Map<UserDao>(user);
        dbContext.Users.Add(dao);
    }
}