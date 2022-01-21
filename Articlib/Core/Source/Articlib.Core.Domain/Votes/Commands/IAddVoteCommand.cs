using Articlib.Core.Domain.Votes.Models;

namespace Articlib.Core.Domain.Votes.Commands;

public interface IAddVoteCommand
{
    void Add(Vote vote);
}
