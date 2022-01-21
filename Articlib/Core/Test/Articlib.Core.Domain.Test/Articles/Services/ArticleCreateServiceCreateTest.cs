using Articlib.Core.Domain.Articles;
using LittleByte.Validation;
using LittleByte.Validation.Test.Categories;
using LittleByte.Validation.Test.TestUtilities;
using NSubstitute;
using NUnit.Framework;

namespace Articlib.Core.Domain.Test.Articles;

public class ArticleCreateServiceCreateTest : UnitTest
{
    private ArticleCreateService testObj = null!;
    private IModelValidator<Article> validator = null!;
    private IAddArticleCommand command = null!;

    [SetUp]
    public void SetUp()
    {
        validator = Substitute.For<IModelValidator<Article>>();
        command = Substitute.For<IAddArticleCommand>();

        testObj = new ArticleCreateService(validator, command);

        validator.Sign(null!).ReturnsForAnyArgs(ValidModel.Succeeded<Article>());
    }

    [Test]
    public void When_ValidationPasses_Then_AddToRepo()
    {
        testObj.Create(TV.Articles.Url, TV.Users.Id());

        command.ReceivedWithAnyArgs(1).Add(new Valid<Article>());
    }

    [Test]
    public void When_ValidationFails_Then_DontAddToRepo()
    {
        validator.Sign(null!).ReturnsForAnyArgs(ValidModel.Failed<Article>());

        testObj.Create(TV.Articles.Url, TV.Users.Id());

        command.DidNotReceiveWithAnyArgs().Add(new Valid<Article>());
    }
}
