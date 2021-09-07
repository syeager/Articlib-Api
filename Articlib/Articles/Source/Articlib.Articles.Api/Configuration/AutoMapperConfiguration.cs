using AutoMapper;

namespace Articlib.Articles.Api;

public static class AutoMapperConfiguration
{
    public static IServiceCollection AddAutoMapper(this IServiceCollection services)
    {
        return services
            .AddScoped(serviceProvider => new MapperConfiguration(config =>
            {
                config
                    .AddApi(serviceProvider)
                    .AddPersistence(serviceProvider);
            }).CreateMapper());
    }

    private static IMapperConfigurationExpression AddApi(this IMapperConfigurationExpression config, IServiceProvider serviceProvider)
    {
        var entityIdCache = serviceProvider.GetRequiredService<IEntityIdReadCache>();
        var articleProfile = new ArticleProfile(entityIdCache);
        config.AddProfile(articleProfile);
        return config;
    }
}
