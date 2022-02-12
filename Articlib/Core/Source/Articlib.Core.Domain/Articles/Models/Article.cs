using System.Collections.ObjectModel;
using Articlib.Core.Domain.Articles.Exceptions;
using LittleByte.Domain;

namespace Articlib.Core.Domain.Articles;

public sealed class Article
{
    public Id<Article> Id { get; }
    public Uri Url { get; }
    public uint VoteCount { get; private set; }
    public IReadOnlyCollection<ArticleTag> Tags { get; }

    private Article(Id<Article> id, Uri url, uint voteCount, IList<ArticleTag> tags)
    {
        Id = id;
        Url = url;
        VoteCount = voteCount;
        Tags = new ReadOnlyCollection<ArticleTag>(tags);
    }

    public static Valid<Article> Create(
        IModelValidator<Article> articleValidator,
        Id<Article> id,
        Uri url,
        uint voteCount,
        IList<ArticleTag> tags)
    {
        var article = new Article(id, url, voteCount, tags);
        var validArticle = articleValidator.Sign(article);
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
}
