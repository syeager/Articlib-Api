using Articlib.Core.Domain.Users;
using LittleByte;
using LittleByte.Validation.Test;
using LittleByte.Validation.Test.TestUtilities;
using NUnit.Framework;

namespace Articlib.Core.Domain.Test.Users.Validators;

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
        var result = User.Create(testObj, Valid.User.Email, Valid.User.Name);

        Assert.IsTrue(result.IsSuccess);
    }

    [Test]
    public void When_InvalidEmail_Return_Fail()
    {
        var result = User.Create(testObj, "", Valid.User.Name);

        result.AssertFirstError(nameof(User.Email), nameof(EmailValidator<X>));
    }

    [Test]
    public void When_InvalidName_Return_Fail()
    {
        var result = User.Create(testObj, Valid.User.Email, "");

        result.AssertFirstError(nameof(User.Name), nameof(NameValidator<X>));
    }
}
