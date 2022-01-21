using Articlib.Core.Domain.Users;
using LittleByte.Validation;

namespace Articlib.Core.Api.Users;

internal static class UserConfiguration
{
    public static IServiceCollection AddUsers(this IServiceCollection @this) =>
        @this
            .AddTransient<IModelValidator<User>, ModelValidator<User>>()
            .AddTransient<IUserRegisterService, UserRegisterService>()
            .AddTransient<ILogInService, LogInService>();
}
