using Articlib.Core.Domain.Users;
using LittleByte.Validation;
using LittleByte.Validation.Test;
using LittleByte.Validation.Test.TestUtilities;
using NSubstitute;
using NUnit.Framework;

namespace Articlib.Core.Domain.Test.Users;

internal class UserTest : UnitTest
{
    private IModelValidator<User> validator = null!;

    [SetUp]
    public void SetUp()
    {
        validator = Substitute.For<IModelValidator<User>>();
        validator.Sign(null!).ReturnsForAnyArgs(ValidModel.Succeeded<User>());
    }

    [Test]
    public void When_Valid_Return_Valid()
    {
        var result = User.Create(validator, TV.Users.Id(), TV.Users.Email, TV.Users.Name);

        Assert.IsTrue(result.IsSuccess);
    }

    [Test]
    public void When_ValidationFails_Return_Fail()
    {
        validator.Sign(null!).ReturnsForAnyArgs(ValidModel.Failed<User>());

        var result = User.Create(validator, TV.Users.Id(), TV.Users.Email, TV.Users.Name);

        Assert.IsFalse(result.IsSuccess);
    }
}
