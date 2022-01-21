using Articlib.Users.Domain.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Articlib.Users.Infra.Persistence.Queries;

public interface IFindUsersByIdQuery
{
    Task<IReadOnlyCollection<User>> SendAsync(IReadOnlyCollection<Guid> ids);
}

internal sealed class FindUsersByIdQuery : IFindUsersByIdQuery
{
    private readonly UsersContext dbContext;
    private readonly IMapper mapper;

    public FindUsersByIdQuery(UsersContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }

    public async Task<IReadOnlyCollection<User>> SendAsync(IReadOnlyCollection<Guid> ids)
    {
        var entities = await dbContext.Users
            .Where(u => ids.Contains(u.Id))
            .ToArrayAsync();

        var users = entities
            .Select(mapper.Map<User>) // TODO: not gonna work
            .ToArray();

        return users;
    }
}
