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
        var (id, articleTags) = TV.Articles.IdAndArticleTags();
        var result = Article.Create(passValidator, id, TV.Articles.Url, 0, articleTags);

        Assert.IsTrue(result.IsSuccess);
    }

    [Test]
    public void When_ValidationFails_Then_DontThrow()
    {
        var (id, articleTags) = TV.Articles.IdAndArticleTags();
        var result = Article.Create(failValidator, id, null!, 0, articleTags);

        Assert.IsFalse(result.IsSuccess);
    }
}
