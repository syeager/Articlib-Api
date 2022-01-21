using NUnit.Framework;

namespace Articlib.Articles.Domain.Test.Articles;

public class ArticleAddVoteTest
{
    [Test]
    public void When_VoteAdded_Then_VoteCountIncreasesBy1()
    {
        var article = TV.Articles.Valid();

        var initialValue = article.VoteCount;
        article.AddVote();
        
        Assert.AreEqual(initialValue + 1, article.VoteCount);
    }

    [Test]
    public void When_VoteCountExceedsMax_Then_ThrowException()
    {
        // TODO
    }
}
