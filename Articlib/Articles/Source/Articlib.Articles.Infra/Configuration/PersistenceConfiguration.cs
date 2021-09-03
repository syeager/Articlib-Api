using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Articlib.Articles.Infra;

public static class PersistenceConfiguration
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        return services
            .AddDbContext<ArticleDb>(builder => builder.UseInMemoryDatabase("articles"))
            .AddScoped<IArticleReadRepo, ArticleRepo>()
            .AddScoped<IArticleWriteRepo, ArticleRepo>()
            .AddScoped<IEntityIdReadCache, IEntityIdWriteCache, EntityIdCache>();
    }
}
