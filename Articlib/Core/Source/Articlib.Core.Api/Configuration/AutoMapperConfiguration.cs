using Articlib.Core.Api.Articles.Configuration;
using Articlib.Core.Api.Users.Configuration;
using AutoMapper;

namespace Articlib.Core.Api.Configuration;

public static class AutoMapperConfiguration
{
    public static IServiceCollection AddAutoMapper(this IServiceCollection services)
    {
        return services
            .AddScoped(serviceProvider => new MapperConfiguration(config =>
            {
                config
                    .AddArticles()
                    .AddUsers();
            })
            .CreateMapper());
    }

}
