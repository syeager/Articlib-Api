using AutoMapper;

namespace Articlib.Core.Api.Articles;

public static class ArticleMappingConfiguration
{
    public static IMapperConfigurationExpression AddArticles(this IMapperConfigurationExpression @this)
    {
        @this.AddProfile<ArticleProfile>();
        @this.AddProfile<Infra.Articles.ArticleProfile>();
        return @this;
    }
}