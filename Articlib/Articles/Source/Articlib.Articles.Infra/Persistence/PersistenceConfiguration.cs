using Articlib.Articles.Domain.Articles;
using Articlib.Articles.Domain.Votes.Commands;
using Articlib.Articles.Domain.Votes.Queries;
using Articlib.Articles.Infra.Persistence.Commands.Votes;
using Articlib.Articles.Infra.Persistence.Queries;
using LittleByte.Extensions.Pomelo.EntityFrameworkCore.MySql;
using LittleByte.Infra.Commands;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Articlib.Articles.Infra.Persistence;

public static class PersistenceConfiguration
{
    public static IServiceCollection AddArticlePersistence(this IServiceCollection @this, IConfiguration configuration)
    {
        return @this
            .AddArticles()
            .AddVotes()
            .AddScoped<ISaveContextCommand, SaveContextCommand<ArticlesContext>>()
            .AddMySql<ArticlesContext>(configuration);
    }

    private static IServiceCollection AddArticles(this IServiceCollection @this)
    {
        return @this
            .AddScoped<IFilterArticlesQuery, FilterQuery>()
            .AddScoped<IAddArticleCommand, AddArticleCommand>();
    }

    private static IServiceCollection AddVotes(this IServiceCollection @this)
    {
        return @this
            .AddTransient<IFindVoteQuery, FindVoteQuery>()
            .AddScoped<IAddVoteCommand, AddVoteCommand>();
    }
}
