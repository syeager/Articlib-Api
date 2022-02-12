using Articlib.Core.Domain.Articles;
using Articlib.Core.Domain.Users;
using LittleByte.Validation.Test.Categories;

namespace Articlib.Core.Domain.Test.Votes.Services;

public abstract class VoteServiceTest : UnitTest
{
    protected static (Article article, User user, uint voteCount) NewArticleAndUser()
    {
        const int voteCount = 1;
        var article = TV.Articles.New(voteCount).GetModelOrThrow();
        var user = TV.Users.New().GetModelOrThrow();
        return (article, user, voteCount);
    }
}

