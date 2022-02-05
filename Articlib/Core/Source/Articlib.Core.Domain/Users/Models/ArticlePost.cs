using Articlib.Core.Domain.Articles;
using LittleByte.Domain;

namespace Articlib.Core.Domain.Users;

public sealed record ArticlePost(Id<User> User, Id<Article> ArticleId, DateTime PostTime);
