using LittleByte.Domain;
using LittleByte.Validation;
using LittleByte.Validation.Test;
using NUnit.Framework;

namespace Articlib.Core.Domain.Test;

public class ArticleCreateTest : UnitTest
{
    private readonly FailModelValidator<Article> failValidator = new();
    private readonly SuccessModelValidator<Article> passValidator = new();

    [Test]
    public void When_ValidationPasses_Then_ReturnModel()
    {
        var result = Article.Create(passValidator, TV.Articles.Id(), TV.Articles.Url, Id<User>.Empty);

        Assert.IsTrue(result.IsSuccess);
    }

    [Test]
    public void When_ValidationFails_Then_DontThrow()
    {
        var result = Article.Create(failValidator, TV.Articles.Id(), null!, TV.Users.Id());

        Assert.IsFalse(result.IsSuccess);
    }
}
