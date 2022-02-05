using Articlib.Core.Domain.Articles;
using LittleByte.Validation;
using LittleByte.Validation.Test.Categories;
using NUnit.Framework;

namespace Articlib.Core.Domain.Test.Articles;

public class ArticleCreateTest : UnitTest
{
    private readonly FailModelValidator<Article> failValidator = new();
    private readonly SuccessModelValidator<Article> passValidator = new();

    [Test]
    public void When_ValidationPasses_Then_ReturnModel()
    {
        var result = Article.Create(passValidator, TV.Articles.Id(), TV.Articles.Url, 0);

        Assert.IsTrue(result.IsSuccess);
    }

    [Test]
    public void When_ValidationFails_Then_DontThrow()
    {
        var result = Article.Create(failValidator, TV.Articles.Id(), null!, 0);

        Assert.IsFalse(result.IsSuccess);
    }
}
