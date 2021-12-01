using Articlib.Core.Domain.Users;
using LittleByte.Validation;
using LittleByte.Validation.Test.TestUtilities;
using NSubstitute;
using NUnit.Framework;

namespace Articlib.Core.Domain.Test.Users;

public class UserRegisterServiceTest
{
    private UserRegisterService testObj = null!;
    private IUserRepo userRepo = null!;
    private IModelValidator<User> userValidator = null!;

    [SetUp]
    public void SetUp()
    {
        userRepo = Substitute.For<IUserRepo>();
        userValidator = Substitute.For<IModelValidator<User>>();

        testObj = new UserRegisterService(userRepo, userValidator);

        userValidator.Pass();
    }

    [Test]
    public void When_ValidationPasses_Then_AddToRepo()
    {
        var result = testObj.Register(Valid.User.Email, Valid.User.Name);

        Assert.IsTrue(result.IsSuccess);
        userRepo.Received(1).Add(Arg.Any<Valid<User>>());
    }

    [Test]
    public void When_ValidationFails_Then_DontAddToRepo()
    {
        userValidator.Fail();

        var result = testObj.Register(Valid.User.Email, Valid.User.Name);

        Assert.IsFalse(result.IsSuccess);
        userRepo.DidNotReceive().Add(Arg.Any<Valid<User>>());
    }
}