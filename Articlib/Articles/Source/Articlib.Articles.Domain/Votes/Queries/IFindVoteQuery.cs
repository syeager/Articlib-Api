using Articlib.Articles.Domain.Articles;
using Articlib.Articles.Domain.Users;
using Articlib.Articles.Domain.Votes.Models;
using LittleByte.Domain;

namespace Articlib.Articles.Domain.Votes.Queries;

public interface IFindVoteQuery
{
    Task<Vote?> FindAsync(Id<Article> articleId, Id<User> userId);
}
