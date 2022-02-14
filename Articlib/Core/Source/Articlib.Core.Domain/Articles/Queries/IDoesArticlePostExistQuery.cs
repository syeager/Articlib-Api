using Articlib.Core.Domain.Users;

namespace Articlib.Core.Domain.Articles.Queries;

public interface IDoesArticlePostExistQuery
{
    Task<bool> SearchAsync(Id<User> userId, Id<Article> articleId);
}
