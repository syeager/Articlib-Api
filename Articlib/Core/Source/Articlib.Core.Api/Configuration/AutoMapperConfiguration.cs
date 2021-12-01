using Articlib.Core.Api.Articles;
using Articlib.Core.Api.Users;
using AutoMapper;

namespace Articlib.Core.Api.Configuration;

public static class AutoMapperConfiguration
{
    public static IServiceCollection AddAutoMapper(this IServiceCollection services)
    {
        return services
            .AddScoped(_ => new MapperConfiguration(config =>
            {
                config
                    .AddArticles()
                    .AddUsers();
            })
            .CreateMapper());
    }
}
