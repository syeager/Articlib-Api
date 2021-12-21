using Articlib.Core.Domain.Users;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Articlib.Core.Infra.Users;

public interface IFindUsersByIdQuery
{
    Task<IReadOnlyCollection<User>> SendAsync(IReadOnlyCollection<Guid> ids);
}

internal class FindUsersByIdQuery
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
            .Select(mapper.Map<User>)
            .ToArray();

        return users;
    }
}