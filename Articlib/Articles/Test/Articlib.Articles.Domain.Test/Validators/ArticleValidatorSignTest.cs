using LittleByte.Core.Common;
using LittleByte.Domain;
using LittleByte.Validation.Test;
using LittleByte.Validation.Test.TestUtilities;
using LittleByte.Validation.Validators;
using NUnit.Framework;

namespace Articlib.Core.Domain.Test;

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
        var result = testObj.Sign(TV.Articles.Valid());

        Assert.IsTrue(result.IsSuccess);
    }

    [Test]
    public void Given_EmptyId_Return_Failure()
    {
        var result = Article.Create(testObj, Id<Article>.Empty, TV.Articles.Url, TV.Users.Id());

        result.AssertFirstError(nameof(Article.Id), nameof(IdValidator<X, X>));
    }

    [Test]
    public void Given_EmptyPosterId_Return_Failure()
    {
        var result = Article.Create(testObj, TV.Articles.Id(), TV.Articles.Url, Id<User>.Empty);

        result.AssertFirstError(nameof(Article.PosterId), nameof(IdValidator<X, X>));
    }

    [Test]
    public void Given_RelativeUrl_Return_Failure()
    {
        var url = TV.Articles.Url.MakeRelativeUri(TV.Articles.Url);

        var result = Article.Create(testObj, TV.Articles.Id(), url, TV.Users.Id());

        result.AssertFirstError(nameof(Article.Url), nameof(AbsoluteUriValidator<X>));
    }
}
