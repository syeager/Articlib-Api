using Articlib.Core.Domain.Articles;
using LittleByte.Core.Common;
using LittleByte.Domain;
using LittleByte.Validation.Test.Categories;
using LittleByte.Validation.Test.TestUtilities;
using LittleByte.Validation.Validators;
using NUnit.Framework;

namespace Articlib.Core.Domain.Test.Articles;

public class ArticleValidatorSignTest : UnitTest
{
    private ArticleValidator testObj = null!;

    [SetUp]
    public void SetUp()
    {
        testObj = new ArticleValidator();
    }

    [Test]
    public void Given_ValidValues_Return_Success()
    {
        var result = testObj.Sign(TV.Articles.New().GetModelOrThrow());

        Assert.IsTrue(result.IsSuccess);
    }

    [Test]
    public void Given_EmptyId_Return_Failure()
    {
        var result = Article.Create(testObj, Id<Article>.Empty, TV.Articles.Url, 0, 0, DateTime.MinValue);

        result.AssertFirstError(nameof(Article.Id), nameof(IdValidator<X, X>));
    }

    [Test]
    public void Given_RelativeUrl_Return_Failure()
    {
        var url = TV.Articles.Url.MakeRelativeUri(TV.Articles.Url);

        var result = Article.Create(testObj, TV.Articles.Id(), url, 0, 0, DateTime.MinValue);

        result.AssertFirstError(nameof(Article.Url), nameof(AbsoluteUriValidator<X>));
    }
}
