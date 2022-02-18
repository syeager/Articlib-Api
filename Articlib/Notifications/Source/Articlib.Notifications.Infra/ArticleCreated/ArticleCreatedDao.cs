using Articlib.Notifications.Infra.Models;
using JetBrains.Annotations;

namespace Articlib.Notifications.Infra.ArticleCreated;

public interface IArticleCreated
{
    Guid UserId { get; }
    Guid ArticleId { get; }
}

internal sealed class ArticleCreatedDao : NotificationDao, IArticleCreated
{
    public Guid ArticleId { get; set; }

    [UsedImplicitly]
    public ArticleCreatedDao() { }

    public ArticleCreatedDao(Guid userId, Guid articleId)
    {
        UserId = userId;
        ArticleId = articleId;
    }
}
