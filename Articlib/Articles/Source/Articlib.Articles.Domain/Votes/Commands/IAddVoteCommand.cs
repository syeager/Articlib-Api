using Articlib.Articles.Domain.Votes.Models;

namespace Articlib.Articles.Domain.Votes.Commands;

public interface IAddVoteCommand
{
    void Add(Vote vote);
}
