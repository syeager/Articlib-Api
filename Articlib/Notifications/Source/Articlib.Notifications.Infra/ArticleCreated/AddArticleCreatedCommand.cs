using Articlib.Notifications.Infra.Persistence.Contexts;

namespace Articlib.Notifications.Infra.ArticleCreated;

public interface IAddArticleCreatedCommand
{
    void AddRange(IReadOnlyCollection<IArticleCreated> notifications);
}

internal sealed class AddArticleCreatedCommand : IAddArticleCreatedCommand
{
    private readonly NotificationsDb notificationsDb;

    public AddArticleCreatedCommand(NotificationsDb notificationsDb)
    {
        this.notificationsDb = notificationsDb;
    }

    public void AddRange(IReadOnlyCollection<IArticleCreated> notifications)
    {
        var entities = notifications.Select(n => new ArticleCreatedDao(n.UserId, n.ArticleId));

        notificationsDb.ArticleCreated.AddRange(entities);

        // TODO: This is just temporary. The goal is to finish the SQL transaction and save once the request is finished.
        notificationsDb.SaveChanges();
    }
}
