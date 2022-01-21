using Articlib.Core.Domain;
using LittleByte.Extensions.Pomelo.EntityFrameworkCore.MySql;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Articlib.Core.Infra;

public static class PersistenceConfiguration
{
    public static IServiceCollection AddArticlePersistence(this IServiceCollection @this, IConfiguration configuration)
    {
        return @this
            .AddMySql<ArticlesContext>(configuration)
            .AddScoped<IArticleFilterRepo, ArticleFilterRepo>()
            .AddScoped<IAddArticleCommand, AddArticleCommand>();
    }
}
