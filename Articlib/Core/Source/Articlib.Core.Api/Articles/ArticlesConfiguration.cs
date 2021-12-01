using Articlib.Core.Domain.Articles;
using Articlib.Core.Infra.Articles;
using LittleByte.Validation;

namespace Articlib.Core.Api.Articles;

public static class ArticlesConfiguration
{
    public static IServiceCollection AddArticles(this IServiceCollection @this, IConfiguration configuration)
    {
        return @this
            .AddTransient<IModelValidator<Article>, ArticleValidator>()
            .AddTransient<IArticleCreateService, ArticleCreateService>()
            .AddArticlePersistence(configuration);
    }
}