using Articlib.Core.Domain.Articles;
using Articlib.Core.Domain.Articles.Queries;
using Articlib.Core.Domain.Users;
using Articlib.Core.Infra.Persistence;
using LittleByte.Domain;
using Microsoft.EntityFrameworkCore;

namespace Articlib.Core.Infra.Articles.Queries;

internal sealed class DoesArticlePostExistQuery : IDoesArticlePostExistQuery
{
    private readonly CoreDb coreDb;

    public DoesArticlePostExistQuery(CoreDb coreDb)
    {
        this.coreDb = coreDb;
    }

    public async Task<bool> SearchAsync(Id<User> userId, Id<Article> articleId)
    {
        var postExists =
            await coreDb.ArticlePosts.AnyAsync(ap => ap.UserId == userId.Value && ap.ArticleId == articleId.Value);
        return postExists;
    }
}
