using Articlib.Notifications.Infra.ArticleCreated;
using Articlib.Notifications.Infra.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Articlib.Notifications.Infra.Persistence;

public static class PersistenceConfiguration
{
    public static IServiceCollection AddPersistence(this IServiceCollection @this)
    {
        // TODO: This is just temporary. We will eventually have a separate entry point to configure this layer that will call this method internally.
        @this.AddTransient<IAddArticleCreatedCommand, AddArticleCreatedCommand>();

        return @this.AddDbContext<NotificationsDb>(builder => { builder.UseInMemoryDatabase("Notifications"); });
    }
}
