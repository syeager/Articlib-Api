using Articlib.Core.Domain.Articles;
using Articlib.Core.Infra.Articles.Commands;
using Articlib.Core.Infra.Articles.Models;
using Articlib.Core.Infra.Articles.Queries;
using Articlib.Core.Infra.Persistence;
using LittleByte.Infra.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace Articlib.Core.Infra.Articles;

internal static class ArticlePersistenceConfiguration
{
    internal static IServiceCollection AddArticles(this IServiceCollection @this)
    {
        return @this
            .AddScoped<IFindByIdQuery<Article>, FindByIdQuery<Article, ArticleDao, CoreDb>>()
            .AddScoped<IFilterArticlesQuery, FilterQuery>()
            .AddScoped<IAddArticleCommand, AddArticleCommand>();
    }
}
