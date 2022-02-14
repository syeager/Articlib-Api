using Articlib.Core.Domain.Articles;
using Articlib.Core.Domain.Users;
using JetBrains.Annotations;

namespace Articlib.Core.Domain.Votes.Models;

public sealed class Vote
{
    public Id<Article> ArticleId { get; init; }
    public Id<User> UserId { get; init; }
    public DateTime Date { get; init; }

    [UsedImplicitly]
    public Vote() { }

    public Vote(Id<Article> articleId, Id<User> userId, DateTime date)
    {
        ArticleId = articleId;
        UserId = userId;
        Date = date;
    }
}
