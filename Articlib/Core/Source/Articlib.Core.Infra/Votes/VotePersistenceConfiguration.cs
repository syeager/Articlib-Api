using Articlib.Core.Domain.Votes.Commands;
using Articlib.Core.Domain.Votes.Queries;
using Articlib.Core.Infra.Votes.Commands;
using Articlib.Core.Infra.Votes.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace Articlib.Core.Infra.Votes;

internal static class VotePersistenceConfiguration
{
    public static IServiceCollection AddVotes(this IServiceCollection @this)
    {
        return @this
            .AddTransient<IFindVoteQuery, FindVoteQuery>()
            .AddScoped<IAddVoteCommand, AddVoteCommand>()
            .AddScoped<IRemoveVoteCommand, RemoveVoteCommand>();
    }
}
