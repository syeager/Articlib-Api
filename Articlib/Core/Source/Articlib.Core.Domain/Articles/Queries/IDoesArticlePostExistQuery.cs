using Articlib.Core.Domain.Users;
using LittleByte.Domain;

namespace Articlib.Core.Domain.Articles.Queries;

public interface IDoesArticlePostExistQuery
{
    Task<bool> SearchAsync(Id<User> userId, Id<Article> articleId);
}
