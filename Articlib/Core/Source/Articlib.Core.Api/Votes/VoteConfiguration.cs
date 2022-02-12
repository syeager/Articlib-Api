using Articlib.Core.Domain.Votes.Services;

namespace Articlib.Core.Api.Votes;

public static class VoteConfiguration
{
    public static IServiceCollection AddVotes(this IServiceCollection @this)
    {
        return @this
            .AddTransient<IAddVoteService, AddVoteService>()
            .AddTransient<IRemoveVote, RemoveVote>();
    }
}
