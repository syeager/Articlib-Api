using LittleByte.Configuration;
using LittleByte.Messaging;
using LittleByte.Messaging.RabbitMq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Articlib.Notifications.Infra.Messaging;

public static class MessagingConfiguration
{
    public static IServiceCollection AddInfraMessaging(this IServiceCollection @this, IConfiguration configuration)
    {
        @this.BindOptions<RabbitMqOptions>(configuration);

        return @this
            .AddSingleton<IMessageDeserializer, JsonTextDeserializer>()
            .AddSingleton<IConsumerFactory, ReflectionConsumerFactory>()
            .AddHostedService<RabbitMqBroker>();
    }
}