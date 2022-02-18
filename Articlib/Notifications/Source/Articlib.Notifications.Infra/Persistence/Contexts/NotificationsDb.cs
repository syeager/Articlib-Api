using Articlib.Notifications.Infra.ArticleCreated;
using Articlib.Notifications.Infra.Models;
using Microsoft.EntityFrameworkCore;

namespace Articlib.Notifications.Infra.Persistence.Contexts;

internal sealed class NotificationsDb : DbContext
{
    public DbSet<ArticleCreated.ArticleCreatedDao> ArticleCreated { get; set; } = null!;

    public NotificationsDb(DbContextOptions<NotificationsDb> options)
        : base(options) { }
}
