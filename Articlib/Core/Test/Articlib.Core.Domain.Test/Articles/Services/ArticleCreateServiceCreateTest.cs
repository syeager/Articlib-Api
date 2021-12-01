using Articlib.Core.Domain.Articles;
using LittleByte.Validation;
using LittleByte.Validation.Test;
using LittleByte.Validation.Test.TestUtilities;
using NSubstitute;
using NUnit.Framework;

namespace Articlib.Core.Domain.Test.Articles;

public class ArticleCreateServiceCreateTest : UnitTest
{
    private ArticleCreateService testObj = null!;
    private IModelValidator<Article> validator = null!;
    private IArticleRepo repo = null!;

    [SetUp]
    public void SetUp()
    {
        validator = Substitute.For<IModelValidator<Article>>();
        repo = Substitute.For<IArticleRepo>();

        testObj = new ArticleCreateService(validator, repo);

        validator.Sign(null!).ReturnsForAnyArgs(ValidModel.Succeeded<Article>());
    }

    [Test]
    public void When_ValidationPasses_Then_AddToRepo()
    {
        testObj.Create(TV.Articles.Url, TV.Users.Id());

        repo.ReceivedWithAnyArgs(1).Add(new Valid<Article>());
    }

    [Test]
    public void When_ValidationFails_Then_DontAddToRepo()
    {
        validator.Sign(null!).ReturnsForAnyArgs(ValidModel.Failed<Article>());

        testObj.Create(TV.Articles.Url, TV.Users.Id());

        repo.DidNotReceiveWithAnyArgs().Add(new Valid<Article>());
    }
}
