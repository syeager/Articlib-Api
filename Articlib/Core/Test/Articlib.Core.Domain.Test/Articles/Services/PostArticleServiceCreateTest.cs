using Articlib.Core.Domain.Articles;
using Articlib.Core.Domain.Articles.Exceptions;
using Articlib.Core.Domain.Articles.Queries;
using Articlib.Core.Domain.Users;
using LittleByte.Core.Dates;
using LittleByte.Validation;
using LittleByte.Validation.Test.Categories;
using LittleByte.Validation.Test.TestUtilities;
using NSubstitute;
using NUnit.Framework;

namespace Articlib.Core.Domain.Test.Articles;

public class PostArticleServiceCreateTest : UnitTest
{
    private PostArticleService testObj = null!;
    private IModelValidator<Article> validator = null!;
    private IAddArticleCommand addArticleCommand = null!;
    private IFindArticleByUrlQuery findArticleByUrlQuery = null!;
    private IDoesArticlePostExistQuery doesArticlePostExistQuery = null!;
    private IAddArticlePostCommand addArticlePostCommand = null!;

    [SetUp]
    public void SetUp()
    {
        validator = Substitute.For<IModelValidator<Article>>();
        addArticleCommand = Substitute.For<IAddArticleCommand>();
        var dateService = Substitute.For<IDateService>();
        findArticleByUrlQuery = Substitute.For<IFindArticleByUrlQuery>();
        doesArticlePostExistQuery = Substitute.For<IDoesArticlePostExistQuery>();
        addArticlePostCommand = Substitute.For<IAddArticlePostCommand>();

        testObj = new PostArticleService(
            validator,
            addArticleCommand,
            dateService,
            findArticleByUrlQuery,
            doesArticlePostExistQuery,
            addArticlePostCommand);

        validator.Sign(null!).ReturnsForAnyArgs(ValidModel.Succeeded<Article>());
    }

    [Test]
    public void When_UserHasPostedArticle_Then_Throw()
    {
        var userId = TV.Users.Id();
        var expected = TV.Articles.Valid();
        var article = expected.GetModelOrThrow();

        findArticleByUrlQuery.FindAsync(TV.Articles.Url).Returns(expected);
        doesArticlePostExistQuery.SearchAsync(userId, article.Id).Returns(true);

        Assert.ThrowsAsync<UserAlreadyPostedArticleException>(() => testObj.FromUserAsync(userId, article.Url));
    }

    [Test]
    public async Task When_ArticleExistsFirstUserPost_Then_PostArticle()
    {
        var userId = TV.Users.Id();
        var expected = TV.Articles.Valid();
        var article = expected.GetModelOrThrow();

        findArticleByUrlQuery.FindAsync(TV.Articles.Url).Returns(expected);

        var result = await testObj.FromUserAsync(userId, article.Url);

        Assert.AreEqual(article.Id, result.GetModelOrThrow().Id);
        addArticleCommand.DidNotReceiveWithAnyArgs().Add(default);
        var expectedPost = new ArticlePost(userId, article.Id, default);
        addArticlePostCommand.Received(1).Add(expectedPost);
    }

    [Test]
    public async Task When_ArticleDoesntExist_Then_CreateArticle()
    {
        var userId = TV.Users.Id();
        var expected = TV.Articles.Valid();
        var article = expected.GetModelOrThrow();

        validator.Sign(default!).ReturnsForAnyArgs(expected);

        var result = await testObj.FromUserAsync(userId, article.Url);

        Assert.AreEqual(article.Id, result.GetModelOrThrow().Id);
        addArticleCommand.ReceivedWithAnyArgs(1).Add(default);
        var expectedPost = new ArticlePost(userId, article.Id, default);
        addArticlePostCommand.Received(1).Add(expectedPost);
    }
}
