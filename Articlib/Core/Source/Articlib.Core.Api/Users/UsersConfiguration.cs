using Articlib.Core.Domain.Users;
using Articlib.Core.Infra.Users;

namespace Articlib.Core.Api.Users;

internal static class UsersConfiguration
{
    public static IServiceCollection AddUsers(this IServiceCollection @this, IConfiguration configuration)
    {
        return @this
            .AddTransient<IUserRegisterService, UserRegisterService>()
            .AddUserPersistence(configuration);
    }
}