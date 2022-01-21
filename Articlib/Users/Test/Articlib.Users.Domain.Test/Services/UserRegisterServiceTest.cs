using Articlib.Users.Domain.Commands;
using Articlib.Users.Domain.Models;
using Articlib.Users.Domain.Services;
using Articlib.Users.Domain.Test.TestUtilities;
using LittleByte.Validation;
using LittleByte.Validation.Test.TestUtilities;
using NSubstitute;
using NUnit.Framework;

namespace Articlib.Users.Domain.Test.Services;

public class UserRegisterServiceTest
{
    private UserRegisterService testObj = null!;
    private IAddUserCommand addUserCommand = null!;
    private IModelValidator<User> userValidator = null!;

    [SetUp]
    public void SetUp()
    {
        addUserCommand = Substitute.For<IAddUserCommand>();
        userValidator = Substitute.For<IModelValidator<User>>();

        testObj = new UserRegisterService(addUserCommand, userValidator);

        userValidator.Pass();
    }

    [Test]
    public async Task When_ValidationPasses_Then_AddToRepo()
    {
        var result = await testObj.RegisterAsync(TV.Users.Email, TV.Users.Name, TV.Users.Password);

        Assert.IsTrue(result.IsSuccess);
        await addUserCommand.Received(1).AddAsync(Arg.Any<Valid<User>>(), TV.Users.Password);
    }

    [Test]
    public async Task When_ValidationFails_Then_DontAddToRepo()
    {
        userValidator.Fail();

        var result = await testObj.RegisterAsync(TV.Users.Email, TV.Users.Name, TV.Users.Password);

        Assert.IsFalse(result.IsSuccess);
        await addUserCommand.DidNotReceiveWithAnyArgs().AddAsync(default!, default!);
    }
}
