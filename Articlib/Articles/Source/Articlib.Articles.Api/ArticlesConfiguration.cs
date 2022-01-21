using Articlib.Articles.Domain.Articles;
using Articlib.Articles.Domain.Votes.Services;
using Articlib.Articles.Infra.Persistence;
using LittleByte.Validation;

namespace Articlib.Articles.Api;

public static class ArticlesConfiguration
{
    public static IServiceCollection AddArticles(this IServiceCollection @this, IConfiguration configuration)
    {
        return @this
            .AddTransient<IAddVote, AddVote>()
            .AddTransient<IModelValidator<Article>, ArticleValidator>()
            .AddTransient<IArticleCreateService, ArticleCreateService>()
            .AddArticlePersistence(configuration);
    }
}
