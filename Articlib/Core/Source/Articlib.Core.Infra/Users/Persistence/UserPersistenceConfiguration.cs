using Articlib.Core.Domain.Users;
using LittleByte.Core.Extensions;
using LittleByte.Validation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Articlib.Core.Infra.Users;

public static class UserPersistenceConfiguration
{
    public static IServiceCollection AddUserPersistence(this IServiceCollection services)
    {
        return services
            .AddDbContext()
            .AddScoped<IModelValidator<User>, CommonUserValidator>()
            .AddScoped<IUserReadRepo, IUserWriteRepo, IUserRepo, UserRepo>();
    }

    private static IServiceCollection AddDbContext(this IServiceCollection services)
    {
        //string connectionString = configuration.GetConnectionString("Articlib");

        // TODO: debug methods
        return services
            .AddDbContext<UserDb>(builder => builder.UseInMemoryDatabase("Users"));
        //.AddDbContext<UserDb>(builder =>
        //    builder.UseMySql(
        //        connectionString,
        //        MySqlServerVersion.LatestSupportedServerVersion,
        //        options => options.MigrationsAssembly("Articlib.Users.DataMigration")));
    }
}