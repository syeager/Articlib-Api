using LittleByte.Domain;

namespace Articlib.Core.Domain.Articles;

public sealed class Article
{
    public Id<Article> Id { get; }
    public Uri Url { get; }
    public uint VoteCount { get; private set; }

    private Article(Id<Article> id, Uri url, uint voteCount)
    {
        Id = id;
        Url = url;
        VoteCount = voteCount;
    }

    public static Valid<Article> Create(
        IModelValidator<Article> articleValidator,
        Id<Article> id,
        Uri url,
        uint voteCount)
    {
        var article = new Article(id, url, voteCount);
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
