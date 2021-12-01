using Articlib.Core.Domain.Articles;
using Articlib.Core.Domain.Users;
using LittleByte.Domain;
using NUnit.Framework;
using Articlib.Core.Domain.Test.Users;
using LittleByte.Validation;
using LittleByte.Validation.Test;

namespace Articlib.Core.Domain.Test.Articles;

public class ArticleCreateTest : UnitTest
{
    private readonly SuccessModelValidator<Article> passValidator = new();
    private readonly FailModelValidator<Article> failValidator = new();

    [Test]
    public void When_ValidationPasses_Then_ReturnModel()
    {
        var result = Article.Create(passValidator, TV.Articles.Id(), TV.Articles.Url, Id<User>.Empty);

        Assert.IsTrue(result.IsSuccess);
    }

    [Test]
    public void When_ValidationFailes_Then_DontThrow()
    {
        var result = Article.Create(failValidator, TV.Articles.Id(), null!, Valid.User.Id());

        Assert.IsFalse(result.IsSuccess);
    }
}
