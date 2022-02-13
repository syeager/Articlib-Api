using Articlib.Core.Domain.Users;
using Articlib.Core.Infra.Persistence;
using AutoMapper;
using LittleByte.Extensions.AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Articlib.Core.Infra.Users.Queries;

public interface IFindUsersByIdQuery
{
    Task<IReadOnlyCollection<User>> SendAsync(IReadOnlyCollection<Guid> ids);
}

internal sealed class FindUsersByIdQuery : IFindUsersByIdQuery
{
    private readonly CoreDb coreDb;
    private readonly IMapper mapper;

    public FindUsersByIdQuery(CoreDb coreDb, IMapper mapper)
    {
        this.coreDb = coreDb;
        this.mapper = mapper;
    }

    public async Task<IReadOnlyCollection<User>> SendAsync(IReadOnlyCollection<Guid> ids)
    {
        var entities = await coreDb.Users
            .Where(u => ids.Contains(u.Id))
            .ToArrayAsync();

        var users = mapper.MapRange<User>(entities);

        return users;
    }
}
