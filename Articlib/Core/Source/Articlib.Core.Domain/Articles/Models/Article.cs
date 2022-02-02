using Articlib.Core.Domain.Users;
using LittleByte.Domain;

namespace Articlib.Core.Domain.Articles;

public sealed class Article
{
    public Id<Article> Id { get; }
    public Uri Url { get; }
    public Id<User> PosterId { get; }
    public uint VoteCount { get; private set; }
    public DateTime PostedDate { get; } // TODO: validate not in the future

    private Article(Id<Article> id, Uri url, Id<User> posterId, DateTime postedDate, uint voteCount)
    {
        Id = id;
        Url = url;
        PosterId = posterId;
        PostedDate = postedDate;
        VoteCount = voteCount;
    }

    public static Valid<Article> Create(
        IModelValidator<Article> articleValidator,
        Id<Article> id,
        Uri url,
        Id<User> posterId,
        DateTime postedDate,
        uint voteCount)
    {
        var article = new Article(id, url, posterId, postedDate, voteCount);
        var validArticle = articleValidator.Sign(article);
        return validArticle;
    }

    public void AddVote()
    {
        // TODO: Handle overflow.
        ++VoteCount;
    }

    public void RemoveVote()
    {
        // TODO: Handle overflow.
        --VoteCount;
    }
}
