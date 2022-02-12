using Articlib.Core.Domain.Articles.Exceptions;
using NUnit.Framework;

namespace Articlib.Core.Domain.Test.Articles;

public class ArticleVoteTest
{
    [Test]
    public void When_VoteAdded_Then_VoteCountIncreasedBy1()
    {
        var article = TV.Articles.New().GetModelOrThrow();

        var initialValue = article.VoteCount;
        article.AddVote();

        Assert.AreEqual(initialValue + 1, article.VoteCount);
    }

    [Test]
    public void When_VoteCountExceedsMax_Then_Throw()
    {
        var article = TV.Articles.New(uint.MaxValue).GetModelOrThrow();

        Assert.Throws<ArticleVoteOverflowException>(() => article.AddVote());
    }

    [Test]
    public void When_VoteRemoved_Then_VoteCountDecreasedBy1()
    {
        var article = TV.Articles.New(1).GetModelOrThrow();

        var initialValue = article.VoteCount;
        article.RemoveVote();

        Assert.AreEqual(initialValue - 1, article.VoteCount);
    }

    [Test]
    public void When_VoteCountExceedsMin_Then_Throw()
    {
        var article = TV.Articles.New().GetModelOrThrow();

        Assert.Throws<ArticleVoteOverflowException>(() => article.RemoveVote());
    }
}
