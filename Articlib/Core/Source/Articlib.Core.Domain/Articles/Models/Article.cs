using Articlib.Core.Domain.Articles.Exceptions;

namespace Articlib.Core.Domain.Articles;

public sealed class Article
{
    public Id<Article> Id { get; }
    public Uri Url { get; }
    public uint VoteCount { get; private set; }
    public uint PostedCount { get; private set; }
    public DateTime LastPostedDate { get; private set; }

    private Article(Id<Article> id, Uri url, uint voteCount, uint postedCount, DateTime lastPostedDate)
    {
        Id = id;
        Url = url;
        VoteCount = voteCount;
        PostedCount = postedCount;
        LastPostedDate = lastPostedDate;
    }

    public static Valid<Article> Create(
        IModelValidator<Article> validator,
        Id<Article> id,
        Uri url,
        uint voteCount,
        uint postedCount,
        DateTime lastPostedDate)
    {
        var article = new Article(id, url, voteCount, postedCount, lastPostedDate);
        var validArticle = validator.Sign(article);
        return validArticle;
    }

    public void AddVote()
    {
        if(VoteCount == uint.MaxValue)
        {
            throw new ArticleVoteOverflowException(this);
        }

        ++VoteCount;
    }

    public void RemoveVote()
    {
        if(VoteCount == uint.MinValue)
        {
            throw new ArticleVoteOverflowException(this);
        }

        --VoteCount;
    }

    public void AddPost(DateTime postedDate)
    {
        ++PostedCount; // TODO: Make new number type.
        LastPostedDate = postedDate;
    }
}
