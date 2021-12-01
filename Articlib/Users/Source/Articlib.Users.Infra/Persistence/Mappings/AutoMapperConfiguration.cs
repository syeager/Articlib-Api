using AutoMapper;
using LittleByte.Infra;
using Microsoft.Extensions.DependencyInjection;

namespace Articlib.Users.Infra;

public static class AutoMapperConfiguration
{
    public static IMapperConfigurationExpression AddPersistence(this IMapperConfigurationExpression config, IServiceProvider serviceProvider)
    {
        var entityIdCache = serviceProvider.GetRequiredService<IEntityIdReadCache>();
        var userProfile = new UserProfile(entityIdCache);
        config.AddProfile(userProfile);
        return config;
    }
}
