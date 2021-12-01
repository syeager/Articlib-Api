using LittleByte.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Articlib.Articles.Infra;

public static class PersistenceConfiguration
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddDbContext(configuration)
            .AddScoped<IArticleReadRepo, ArticleRepo>()
            .AddScoped<IArticleWriteRepo, ArticleRepo>()
            .AddScoped<IEntityIdReadCache, IEntityIdWriteCache, EntityIdCache>();
    }

    private static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("Articlib");

        // TODO: debug methods
        return services
            .AddDbContext<ArticleDb>(builder =>
                builder.UseMySql(
                    connectionString,
                    MySqlServerVersion.LatestSupportedServerVersion,
                    options => options.MigrationsAssembly("Articlib.Articles.DataMigration")));
    }
}
