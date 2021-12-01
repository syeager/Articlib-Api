using Articlib.Core.Infra.Articles;
using Articlib.Core.Infra.Users;

namespace Articlib.Core.Api.Configuration;

public static class InfraConfiguration
{
    public static IServiceCollection AddInfra(this IServiceCollection @this)
    {
        return @this
            .AddArticlePersistence()
            .AddUserPersistence();
    }
}
