using LittleByte.Configuration;
using LittleByte.Core.Extensions;
using LittleByte.Messaging;
using LittleByte.Messaging.RabbitMq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Articlib.Core.Infra.Messaging;

public static class MessagingConfiguration
{
    public static IServiceCollection AddMessaging(this IServiceCollection @this, IConfiguration configuration)
    {
        @this.BindOptions<RabbitMqOptions>(configuration);

        return @this
            .AddSingleton<IMessageSerializer, JsonTextSerializer>()
            .AddHostedService<MessagePublisher, RabbitMqPublisher>();
    }
}