using Articlib.Core.Domain.Votes.Commands;
using Articlib.Core.Domain.Votes.Models;
using Articlib.Core.Domain.Votes.Queries;
using Articlib.Core.Domain.Votes.Services;
using NSubstitute;
using NUnit.Framework;

namespace Articlib.Core.Domain.Test.Votes.Services;

public class RemoveVoteServiceTest : VoteServiceTest
{
    private RemoveVoteService testObj = null!;
    private IFindVoteQuery findVoteQuery = null!;
    private IRemoveVoteCommand removeVoteCommand = null!;

    [SetUp]
    public void SetUp()
    {
        findVoteQuery = Substitute.For<IFindVoteQuery>();
        removeVoteCommand = Substitute.For<IRemoveVoteCommand>();

        testObj = new RemoveVoteService(findVoteQuery, removeVoteCommand);
    }

    [Test]
    public async Task When_VoteDoesntExist_Then_DontUpdateArticleVoteCount()
    {
        var (article, user, voteCount) = NewArticleAndUser();

        findVoteQuery.FindAsync(article.Id, user.Id).Returns((Vote?)null);

        article = await testObj.RemoveAsync(article, user);

        Assert.AreEqual(voteCount, article.VoteCount);
        removeVoteCommand.DidNotReceiveWithAnyArgs().Remove(default!);
    }

    [Test]
    public async Task When_VoteExists_Then_RemoveVoteAndReduceArticleVoteCount()
    {
        var (article, user, voteCount) = NewArticleAndUser();
        var vote = new Vote();

        findVoteQuery.FindAsync(article.Id, user.Id).Returns(vote);

        article = await testObj.RemoveAsync(article, user);

        Assert.AreEqual(voteCount - 1, article.VoteCount);
        removeVoteCommand.Received(1).Remove(vote);
    }
}
