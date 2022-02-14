using Articlib.Core.Domain.Articles;
using JetBrains.Annotations;

namespace Articlib.Core.Domain.Users;

public sealed class ArticlePost
{
    public Id<User> UserId { get; init; }
    public Id<Article> ArticleId { get; init; }
    public DateTime PostDate { get; init; }

    [UsedImplicitly]
    public ArticlePost() { }

    public ArticlePost(Id<User> userId, Id<Article> articleId, DateTime postDate)
    {
        UserId = userId;
        ArticleId = articleId;
        PostDate = postDate;
    }
}
