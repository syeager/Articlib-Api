using LittleByte.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Articlib.Core.Infra.Configuration;

[UsedImplicitly]
internal class MySqlOptions
{
    public string ConnectionString { get; init; } = null!;
    public string Version { get; init; } = null!;

    public void Deconstruct(out string connectionString, out string version)
    {
        connectionString = ConnectionString;
        version = Version;
    }
}

public static class PersistenceConfiguration
{
    internal static IServiceCollection AddMySql<TContext>(this IServiceCollection @this, IConfiguration configuration)
        where TContext : DbContext
    {
        var (connectionString, version) = configuration.GetSection<MySqlOptions>();
        var serverVersion = ServerVersion.Parse(version);

        return @this.AddDbContext<TContext>(builder => builder.UseMySql(connectionString, serverVersion));
    }
}