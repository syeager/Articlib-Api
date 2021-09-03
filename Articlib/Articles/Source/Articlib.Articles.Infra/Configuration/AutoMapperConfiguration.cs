using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Articlib.Articles.Infra;

public static class AutoMapperConfiguration
{
    public static IMapperConfigurationExpression AddPersistence(this IMapperConfigurationExpression config, IServiceProvider serviceProvider)
    {
        var entityIdCache = serviceProvider.GetRequiredService<IEntityIdReadCache>();
        var articleProfile = new ArticleProfile(entityIdCache);
        config.AddProfile(articleProfile);
        return config;
    }
}
