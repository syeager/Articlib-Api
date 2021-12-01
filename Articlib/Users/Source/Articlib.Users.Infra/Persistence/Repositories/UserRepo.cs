using Articlib.Users.Domain.Models;
using Articlib.Users.Domain.Persistence;
using Articlib.Users.Infra.Persistence.Entities;
using AutoMapper;
using LittleByte.Infra;
using LittleByte.Validation;

namespace Articlib.Users.Infra.Persistence.Repositories;

public interface IUserReadRepo : IRepo
{}

public interface IUserWriteRepo : IUserReadRepo
{
    void Add(ValidModel<User> user);
}

internal class UserRepo : Repo<UserDb>, IUserRepo, IUserWriteRepo
{
    public UserRepo(UserDb dbContext, IMapper mapper, IEntityIdWriteCache modelIdCache)
        : base(dbContext, mapper, modelIdCache)
    {
    }

    public void Add(ValidModel<User> user)
    {
        var dao = CreateDao(user.GetModelOrThrow());
        dbContext.Users.Add(dao);
    }

    private UserDao CreateDao(User domain)
    {
        Guid id = Guid.NewGuid();
        Logs.Props().DiagnosticPush("", id); // TODO: log keys
        modelIdCache.Add(domain.Name, id);
        var dao = mapper.Map<UserDao>(domain);
        return dao;
    }
}