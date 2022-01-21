using Articlib.Core.Domain.Articles;
using Articlib.Core.Domain.Users;
using Articlib.Core.Domain.Votes.Models;
using LittleByte.Domain;

namespace Articlib.Core.Domain.Votes.Queries;

public interface IFindVoteQuery
{
    Task<Vote?> FindAsync(Id<Article> articleId, Id<User> userId);
}
