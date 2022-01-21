using Articlib.Core.Domain.Votes.Commands;
using Articlib.Core.Domain.Votes.Models;
using Articlib.Core.Infra.Persistence;
using Articlib.Core.Infra.Votes.Models;
using AutoMapper;

namespace Articlib.Core.Infra.Votes.Commands;

internal sealed class RemoveVoteCommand : IRemoveVoteCommand
{
    private readonly CoreDb coreDb;
    private readonly IMapper mapper;

    public RemoveVoteCommand(CoreDb coreDb, IMapper mapper)
    {
        this.coreDb = coreDb;
        this.mapper = mapper;
    }

    public void Remove(Vote vote)
    {
        var entity = mapper.Map<VoteDao>(vote);
        coreDb.Votes.Remove(entity);
    }
}
