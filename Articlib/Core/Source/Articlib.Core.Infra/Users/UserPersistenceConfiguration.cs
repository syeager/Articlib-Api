using Articlib.Core.Domain.Users;
using Articlib.Core.Domain.Users.Commands;
using Articlib.Core.Domain.Users.Queries;
using Articlib.Core.Infra.Persistence;
using Articlib.Core.Infra.Users.Commands;
using Articlib.Core.Infra.Users.Entities;
using Articlib.Core.Infra.Users.Queries;
using LittleByte.Infra.Commands;
using LittleByte.Infra.Queries;
using LittleByte.Validation;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Articlib.Core.Infra.Users;

internal static class UserPersistenceConfiguration
{
    public static IServiceCollection AddUsers(this IServiceCollection services)
    {
        services
            .AddIdentity<UserDao, UserRole>(options => options.Password = new PasswordOptions
            {
                RequireDigit = false,
                RequiredLength = 1,
                RequireLowercase = false,
                RequireUppercase = false,
                RequiredUniqueChars = 0,
                RequireNonAlphanumeric = false
            })
            .AddEntityFrameworkStores<CoreDb>();

        return services
            .AddTransient<IFindUsersByIdQuery, FindUsersByIdQuery>()
            .AddTransient<IFindByIdQuery<User>, FindByIdQuery<User, UserDao, CoreDb>>()
            .AddTransient<ISaveContextCommand, SaveContextCommand<CoreDb>>()
            .AddTransient<IFindUserByEmailAndPasswordQuery, FindUserByEmailAndPasswordQuery>()
            .AddScoped<IModelValidator<User>, CommonUserValidator>()
            .AddScoped<IAddUserCommand, AddUserCommand>();
    }
}
