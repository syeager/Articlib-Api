using Articlib.Users.Domain.Models;
using Articlib.Users.Domain.Services;
using Articlib.Users.Infra.Persistence;
using LittleByte.Validation;

namespace Articlib.Users.Api;

internal static class UsersConfiguration
{
    public static IServiceCollection AddUsers(this IServiceCollection @this, IConfiguration configuration) =>
        @this
            .AddTransient<IModelValidator<User>, ModelValidator<User>>()
            .AddTransient<IUserRegisterService, UserRegisterService>()
            .AddTransient<ILogInService, LogInService>()
            .AddUserPersistence(configuration);
}
