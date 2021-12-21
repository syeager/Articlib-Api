using Articlib.Core.Domain.Users;
using AutoMapper;
using LittleByte.Core.Exceptions;
using LittleByte.Infra;
using LittleByte.Validation;

namespace Articlib.Core.Infra.Users;

public interface IUserReadRepo : IRepo
{
    public Task<User> GetByIdAsync(Guid id);
}

public interface IUserWriteRepo : IUserReadRepo, IUserRepo
{
}

[UsedImplicitly]
internal class UserRepo : Repo<UsersContext>, IUserWriteRepo
{
    public UserRepo(UsersContext dbContext, IMapper mapper)
        : base(dbContext, mapper)
    {
    }

    public void Add(Valid<User> user)
    {
        var domain = user.GetModelOrThrow();
        var dao = mapper.Map<UserDao>(domain);
        dbContext.Users.Add(dao);
    }

    public async Task<User> GetByIdAsync(Guid id)
    {
        var dao = await dbContext.FindAsync<UserDao>(id);
        if(dao == null)
        {
            throw new NotFoundException(typeof(User), id);
        }

        var user = mapper.Map<User>(dao);
        return user;
    }
}