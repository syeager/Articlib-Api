using AutoMapper;

namespace Articlib.Core.Api.Articles.Configuration;

public static class ArticleMappingConfiguration
{
    public static IMapperConfigurationExpression AddArticles(this IMapperConfigurationExpression @this)
    {
        @this.AddProfile<ArticleProfile>();
        @this.AddProfile<Infra.Articles.Mappings.ArticleProfile>();
        return @this;
    }
}