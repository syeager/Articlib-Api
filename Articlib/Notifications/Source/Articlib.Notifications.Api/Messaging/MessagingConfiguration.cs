using Articlib.Notifications.Infra.Messaging;

namespace Articlib.Notifications.Api.Messaging;

public static class MessagingConfiguration
{
    public static IServiceCollection AddMessaging(this IServiceCollection @this, IConfiguration configuration)
    {
        return
            @this.AddSingleton<ArticleCreatedConsumer>()
            .AddInfraMessaging(configuration);
    }
}
