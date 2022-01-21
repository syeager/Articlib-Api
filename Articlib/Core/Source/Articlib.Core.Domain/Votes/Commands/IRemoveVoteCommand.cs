using Articlib.Core.Domain.Votes.Models;

namespace Articlib.Core.Domain.Votes.Commands;

public interface IRemoveVoteCommand
{
    void Remove(Vote vote);
}
