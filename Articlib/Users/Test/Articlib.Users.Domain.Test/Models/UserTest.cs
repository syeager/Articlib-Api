using Articlib.Users.Domain.Models;
using Articlib.Users.Domain.Validators;
using LittleByte.Validation;
using LittleByte.Validation.Test;
using LittleByte.Validation.Test.TestUtilities;
using NSubstitute;
using NUnit.Framework;
using static Articlib.Users.Domain.Test.TestUtilities.TestValues;

namespace Articlib.Users.Domain.Test.Models;

internal class UserTest : UnitTest
{
    private IUserValidator validator = null!;

    [SetUp]
    public void SetUp()
    {
        validator = Substitute.For<IUserValidator>();
        validator.Sign(null!).ReturnsForAnyArgs(ValidModel.Succeeded<User>());
    }

    [Test]
    public void When_Valid_Return_Valid()
    {
        var result = User.Create(validator, ValidUser.Email, ValidUser.Name);

        Assert.IsTrue(result.IsSuccess);
    }

    [Test]
    public void When_ValidationFails_Return_Fail()
    {
        validator.Sign(null!).ReturnsForAnyArgs(ValidModel.Failed<User>());

        var result = User.Create(validator, ValidUser.Email, ValidUser.Name);

        Assert.IsFalse(result.IsSuccess);
    }
}
