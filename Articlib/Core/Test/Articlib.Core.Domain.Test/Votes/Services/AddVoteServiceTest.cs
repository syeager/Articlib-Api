using Articlib.Core.Domain.Articles;
using Articlib.Core.Domain.Users;
using Articlib.Core.Domain.Votes.Commands;
using Articlib.Core.Domain.Votes.Models;
using Articlib.Core.Domain.Votes.Queries;
using Articlib.Core.Domain.Votes.Services;
using LittleByte.Core.Dates;
using NSubstitute;
using NUnit.Framework;

namespace Articlib.Core.Domain.Test.Votes.Services;

public class AddVoteServiceTest
{
    private AddVoteService testObj = null!;
    private IFindVoteQuery findVoteQuery = null!;
    private IAddVoteCommand addVoteCommand = null!;

    [SetUp]
    public void SetUp()
    {
        var dateService = Substitute.For<IDateService>();
        findVoteQuery = Substitute.For<IFindVoteQuery>();
        addVoteCommand = Substitute.For<IAddVoteCommand>();

        testObj = new AddVoteService(dateService, findVoteQuery, addVoteCommand);
    }

    [Test]
    public async Task When_VoteExists_Then_DontUpdateArticleVoteCount()
    {
        var (article, user, voteCount) = NewArticleAndUser();

        var vote = new Vote();
        findVoteQuery.FindAsync(article.Id, user.Id).Returns(vote);

        article = await testObj.AddAsync(article, user);

        Assert.AreEqual(voteCount, article.VoteCount);
        addVoteCommand.DidNotReceive().Add(vote);
    }

    [Test]
    public async Task When_VoteDoesntExist_Then_CreateVoteAndIncreaseArticleVoteCount()
    {
        var (article, user, voteCount) = NewArticleAndUser();

        article = await testObj.AddAsync(article, user);

        Assert.AreEqual(voteCount + 1, article.VoteCount);
        addVoteCommand.ReceivedWithAnyArgs(1).Add(default!);
    }

    #region Helpers

    private static (Article article, User user, uint voteCount) NewArticleAndUser()
    {
        const int voteCount = 1;
        var article = TV.Articles.New(voteCount).GetModelOrThrow();
        var user = TV.Users.New().GetModelOrThrow();
        return (article, user, voteCount);
    }

    #endregion
}
