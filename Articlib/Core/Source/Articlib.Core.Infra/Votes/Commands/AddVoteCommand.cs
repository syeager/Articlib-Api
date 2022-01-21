using Articlib.Core.Domain.Votes.Commands;
using Articlib.Core.Domain.Votes.Models;
using Articlib.Core.Infra.Persistence;
using Articlib.Core.Infra.Votes.Models;

namespace Articlib.Core.Infra.Votes.Commands;

internal sealed class AddVoteCommand : IAddVoteCommand
{
    private readonly CoreDb coreDb;

    public AddVoteCommand(CoreDb coreDb)
    {
        this.coreDb = coreDb;
    }

    public void Add(Vote vote)
    {
        coreDb.Add<Vote, VoteDao>(vote);
    }
}
