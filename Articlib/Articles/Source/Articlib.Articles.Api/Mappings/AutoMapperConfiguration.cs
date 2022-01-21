using AutoMapper;

namespace Articlib.Articles.Api;

public static class AutoMapperConfiguration
{
    public static IServiceCollection AddAutoMapper(this IServiceCollection services)
    {
        return services
            .AddScoped(_ => new MapperConfiguration(config =>
                {
                    config.AddProfile<ArticleProfile>();
                    config.AddProfile<Infra.Persistence.ArticleProfile>();
                })
                .CreateMapper());
    }
}
