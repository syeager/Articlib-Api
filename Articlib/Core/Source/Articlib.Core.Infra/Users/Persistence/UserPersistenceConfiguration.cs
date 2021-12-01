using Articlib.Core.Domain.Users;
using Articlib.Core.Infra.Configuration;
using LittleByte.Core.Extensions;
using LittleByte.Validation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Articlib.Core.Infra.Users;

public static class UserPersistenceConfiguration
{
    public static IServiceCollection AddUserPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddMySql<UsersContext>(configuration)
            .AddScoped<IModelValidator<User>, CommonUserValidator>()
            .AddScoped<IUserReadRepo, IUserWriteRepo, IUserRepo, UserRepo>();
    }
}