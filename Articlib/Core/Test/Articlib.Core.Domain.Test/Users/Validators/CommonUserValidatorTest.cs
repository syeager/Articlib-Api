using Articlib.Core.Domain.Users;
using LittleByte.Core.Common;
using LittleByte.Domain;
using LittleByte.Validation.Test;
using LittleByte.Validation.Test.TestUtilities;
using NUnit.Framework;

namespace Articlib.Core.Domain.Test.Users;

public class CommonUserValidatorTest : UnitTest
{
    private CommonUserValidator testObj = null!;

    [SetUp]
    public void SetUp()
    {
        testObj = new CommonUserValidator();
    }

    [Test]
    public void When_Valid_Return_Success()
    {
        var result = User.Create(testObj, TV.Users.Id(), Valid.User.Email, Valid.User.Name);

        Assert.IsTrue(result.IsSuccess);
    }

    [Test]
    public void Given_EmptyId_Then_Fail()
    {
        var result = User.Create(testObj, Id<User>.Empty, TV.Users.Email, TV.Users.Name);

        result.AssertFirstError(nameof(User.Id), nameof(IdValidator<X, X>));
    }

    [Test]
    public void When_InvalidEmail_Return_Fail()
    {
        var result = User.Create(testObj, TV.Users.Id(), "", Valid.User.Name);

        result.AssertFirstError(nameof(User.Email), nameof(EmailValidator<X>));
    }

    [Test]
    public void When_InvalidName_Return_Fail()
    {
        var result = User.Create(testObj, TV.Users.Id(), Valid.User.Email, "");

        result.AssertFirstError(nameof(User.Name), nameof(NameValidator<X>));
    }
}