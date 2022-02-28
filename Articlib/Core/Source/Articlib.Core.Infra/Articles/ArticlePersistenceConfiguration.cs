using Articlib.Core.Domain.Articles;
using Articlib.Core.Domain.Articles.Queries;
using Articlib.Core.Infra.Articles.Commands;
using Articlib.Core.Infra.Articles.Models;
using Articlib.Core.Infra.Articles.Queries;
using Articlib.Core.Infra.Persistence;
using LittleByte.Infra.Queries;
using LittleByte.Validation;
using Microsoft.Extensions.DependencyInjection;

namespace Articlib.Core.Infra.Articles;

internal static class ArticlePersistenceConfiguration
{
    internal static IServiceCollection AddArticles(this IServiceCollection @this)
    {
        return @this
            .AddScoped<IFindByIdQuery<Valid<Article>>, FindByIdQuery<Valid<Article>, ArticleDao, CoreDb>>()
            .AddScoped<IFindArticleByUrlQuery, FindArticleByUrlQuery>()
            .AddScoped<IDoesArticlePostExistQuery, DoesArticlePostExistQuery>()
            .AddScoped<IAddArticlePostCommand, AddArticlePostCommand>()
            .AddScoped<IFilterArticlesQuery, FilterQuery>()
            .AddScoped<IAddArticleCommand, AddArticleCommand>();
    }
}
