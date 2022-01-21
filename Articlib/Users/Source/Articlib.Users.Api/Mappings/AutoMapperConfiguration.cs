namespace Articlib.Users.Api.Mappings;

public static class AutoMapperConfiguration
{
    public static IServiceCollection AddAutoMapper(this IServiceCollection services) =>
        services.AddAutoMapper(typeof(UserProfile).Assembly, typeof(Infra.Persistence.Mappings.UserProfile).Assembly);
}
