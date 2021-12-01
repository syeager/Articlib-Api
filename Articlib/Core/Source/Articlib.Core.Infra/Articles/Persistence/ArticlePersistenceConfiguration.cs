using Articlib.Core.Domain.Articles;
using LittleByte.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Articlib.Core.Infra.Articles;

public static class ArticlePersistenceConfiguration
{
    public static IServiceCollection AddArticlePersistence(this IServiceCollection services)
    {
        return services
            .AddDbContext()
            .AddScoped<IArticleRepo, IArticleReadRepo, IArticleWriteRepo, ArticleRepo>();
    }

    private static IServiceCollection AddDbContext(this IServiceCollection services)
    {
        //string connectionString = configuration.GetConnectionString("Articlib");

        // TODO: debug methods
        return services
            .AddDbContext<ArticleDb>(builder => builder.UseInMemoryDatabase("Articles"));
        //.AddDbContext<ArticleDb>(builder =>
        //    builder.UseMySql(
        //        connectionString,
        //        MySqlServerVersion.LatestSupportedServerVersion,
        //        options => options.MigrationsAssembly("Articlib.Articles.DataMigration")));
    }
}
