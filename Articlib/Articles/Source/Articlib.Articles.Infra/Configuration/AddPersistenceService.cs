using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Articlib.Articles.Infra;

public static class AddPersistenceService
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        return services
            .AddAutoMapper(Assembly.GetExecutingAssembly())
            .AddDbContext<ArticleDb>(builder => builder.UseInMemoryDatabase("articles"))
            .AddTransient<IArticleReadRepo, ArticleRepo>()
            .AddTransient<IArticleWriteRepo, ArticleRepo>();
    }
}
