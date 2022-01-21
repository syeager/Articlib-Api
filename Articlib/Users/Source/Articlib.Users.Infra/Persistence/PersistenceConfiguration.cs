using Articlib.Users.Domain.Commands;
using Articlib.Users.Domain.Models;
using Articlib.Users.Domain.Queries;
using Articlib.Users.Domain.Validators;
using Articlib.Users.Infra.Persistence.Commands;
using Articlib.Users.Infra.Persistence.Queries;
using LittleByte.Asp.Identity;
using LittleByte.Extensions.Pomelo.EntityFrameworkCore.MySql;
using LittleByte.Infra.Commands;
using LittleByte.Infra.Queries;
using LittleByte.Validation;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Articlib.Users.Infra.Persistence;

public static class PersistenceConfiguration
{
    public static IServiceCollection AddUserPersistence(this IServiceCollection services, IConfiguration configuration)
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
            .AddEntityFrameworkStores<UsersContext>();

        return services
            .AddTransient()
            .AddScoped()
            .AddMySql<UsersContext>(configuration);
    }

    private static IServiceCollection AddTransient(this IServiceCollection services) =>
        services
            .AddTransient<IFindUsersByIdQuery, FindUsersByIdQuery>()
            .AddTransient<IFindByIdQuery<User>, FindByIdQuery<User, UserDao, UsersContext>>()
            .AddTransient<ITokenGenerator, TokenGenerator>()
            .AddTransient<ISaveContextCommand, SaveContextCommand<UsersContext>>()
            .AddTransient<IFindUserByEmailAndPasswordQuery, FindUserByEmailAndPasswordQuery>();

    private static IServiceCollection AddScoped(this IServiceCollection services) =>
        services
            .AddScoped<IModelValidator<User>, CommonUserValidator>()
            .AddScoped<IAddUserCommand, AddUserCommand>();
}
