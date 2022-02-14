using System.Diagnostics.CodeAnalysis;
using Articlib.Core.Domain.Users;

namespace Articlib.Core.Domain.Articles.Exceptions;

[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
[SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
public sealed class UserAlreadyPostedArticleException : Exception
{
    public Id<User> UserId { get; }
    public Id<Article> ArticleId { get; }

    public UserAlreadyPostedArticleException(Id<User> userId, Id<Article> articleId)
        : base("User has already posted this article")
    {
        UserId = userId;
        ArticleId = articleId;
    }
}
