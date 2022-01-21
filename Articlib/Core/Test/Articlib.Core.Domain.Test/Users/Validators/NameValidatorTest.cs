using Articlib.Core.Domain.Users;
using LittleByte.Core.Common;
using LittleByte.Validation.Test.Categories;
using LittleByte.Validation.Test.TestUtilities;
using NUnit.Framework;

namespace Articlib.Core.Domain.Test.Users;

public class NameValidatorTest : UnitTest
{
    private NameValidator<X> testObj = null!;

    [SetUp]
    public void SetUp()
    {
        testObj = new NameValidator<X>();
    }

    [Test]
    public void When_Empty_Then_Fail()
    {
        var name = new Name("");

        AssertNotValid(name);
    }

    [Test]
    public void Given_Whitespace_Then_Fail()
    {
        var name = new Name(" a ");

        AssertNotValid(name);
    }

    [TestCase(NameRules.LengthMin - 1)]
    [TestCase(NameRules.LengthMax + 1)]
    public void When_WrongLength_Then_Fail(int length)
    {
        var name = new Name(new string('a', length));

        AssertNotValid(name);
    }

    #region Helpers

    private void AssertNotValid(Name name)
    {
        var result = testObj.IsValid(ValidationContextUtility.Empty(), name);

        Assert.IsFalse(result);
    }

    #endregion
}
