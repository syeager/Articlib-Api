using Articlib.Core.Domain.Articles;
using Articlib.Core.Infra.Configuration;
using LittleByte.Core.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Articlib.Core.Infra.Articles;

public static class ArticlePersistenceConfiguration
{
    public static IServiceCollection AddArticlePersistence(this IServiceCollection @this, IConfiguration configuration)
    {
        return @this
            .AddMySql<ArticlesContext>(configuration)
            .AddScoped<IArticleFilterRepo, ArticleFilterRepo>()
            .AddScoped<IArticleRepo, IArticleReadRepo, IArticleWriteRepo, ArticleRepo>();
    }
}