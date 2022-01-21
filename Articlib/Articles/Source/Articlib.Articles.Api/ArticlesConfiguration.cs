using Articlib.Core.Domain;
using Articlib.Core.Infra;
using LittleByte.Validation;

namespace Articlib.Articles.Api;

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
