using Articlib.Core.Infra.Articles;
using Articlib.Core.Infra.Users;
using Articlib.Core.Infra.Votes;
using LittleByte.Extensions.Pomelo.EntityFrameworkCore.MySql;
using LittleByte.Infra.Commands;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Articlib.Core.Infra.Persistence;

public static class PersistenceConfiguration
{
    public static IServiceCollection AddPersistence(this IServiceCollection @this, IConfiguration configuration)
    {
        return @this
            .AddUsers()
            .AddArticles()
            .AddVotes()
            .AddScoped<ISaveContextCommand, SaveContextCommand<CoreDb>>()
            .AddMySql<CoreDb>(configuration);
    }
}
