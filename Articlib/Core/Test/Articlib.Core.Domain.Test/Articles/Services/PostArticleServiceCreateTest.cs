using Articlib.Core.Domain.Articles;
using Articlib.Core.Domain.Articles.Queries;
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

    [SetUp]
    public void SetUp()
    {
        validator = Substitute.For<IModelValidator<Article>>();
        addArticleCommand = Substitute.For<IAddArticleCommand>();
        var dateService = Substitute.For<IDateService>();
        var findArticleByUrlQuery = Substitute.For<IFindArticleByUrlQuery>();
        var doesArticlePostExistQuery = Substitute.For<IDoesArticlePostExistQuery>();
        var addArticlePostCommand = Substitute.For<IAddArticlePostCommand>();

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
    public async Task When_ValidationPasses_Then_AddToRepo()
    {
        await testObj.FromUserAsync(TV.Users.Id(), TV.Articles.Url);

        addArticleCommand.ReceivedWithAnyArgs(1).Add(new Valid<Article>());
    }

    [Test]
    public async Task When_ValidationFails_Then_DontAddToRepo()
    {
        validator.Sign(null!).ReturnsForAnyArgs(ValidModel.Failed<Article>());

        await testObj.FromUserAsync(TV.Users.Id(), TV.Articles.Url);

        addArticleCommand.DidNotReceiveWithAnyArgs().Add(new Valid<Article>());
    }
}
