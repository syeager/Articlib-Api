using Articlib.Users.Domain.Models;
using Articlib.Users.Domain.Validators;
using LittleByte;
using LittleByte.Validation.Test;
using NUnit.Framework;
using static Articlib.Users.Domain.Test.TestUtilities.TestValues;

namespace Articlib.Users.Domain.Test.Validators;

internal class EmailValidatorTest : UnitTest
{
    private EmailValidator<X> testObj = null!;

    [SetUp]
    public void SetUp()
    {
        testObj = new EmailValidator<X>();
    }

    [Test]
    public void When_Valid_Then_Pass()
    {
        var email = new Email(ValidUser.Email);

        var result = testObj.IsValid(ValidationContextUtility.Empty(), email);

        Assert.IsTrue(result);
    }

    [TestCase("bobemail.com")]
    [TestCase("bob@emailcom")]
    public void Given_MissingSymbol_Then_Fail(string emailValue)
    {
        var email = new Email(emailValue);

        var result = testObj.IsValid(ValidationContextUtility.Empty(), email);

        Assert.IsFalse(result);
    }
}
