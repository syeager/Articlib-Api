using Articlib.Users.Infra;
using AutoMapper;
using LittleByte.Infra;

namespace Articlib.Users.Api;

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
        var userProfile = new UserProfile(entityIdCache);
        config.AddProfile(userProfile);
        return config;
    }
}
