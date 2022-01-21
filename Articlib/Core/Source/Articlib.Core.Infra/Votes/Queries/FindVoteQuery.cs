using Articlib.Core.Domain.Articles;
using Articlib.Core.Domain.Users;
using Articlib.Core.Domain.Votes.Models;
using Articlib.Core.Domain.Votes.Queries;
using Articlib.Core.Infra.Persistence;
using AutoMapper;
using LittleByte.Domain;
using Microsoft.EntityFrameworkCore;

namespace Articlib.Core.Infra.Votes.Queries;

internal sealed class FindVoteQuery : IFindVoteQuery
{
    private readonly CoreDb coreDb;
    private readonly IMapper mapper;

    public FindVoteQuery(CoreDb coreDb, IMapper mapper)
    {
        this.coreDb = coreDb;
        this.mapper = mapper;
    }

    public async Task<Vote?> FindAsync(Id<Article> articleId, Id<User> userId)
    {
        var entity = await coreDb.Votes.AsNoTracking()
            .FirstOrDefaultAsync(v => v.ArticleId == articleId.Value && v.UserId == userId.Value);

        Vote? vote = null;
        if(entity is not null)
        {
            vote = mapper.Map<Vote>(entity);
        }

        return vote;
    }
}
