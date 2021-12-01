using Articlib.Users.Domain.Persistence;
using Articlib.Users.Domain.Services;
using Articlib.Users.Domain.Validators;
using NSubstitute;
using NUnit.Framework;

namespace Articlib.Users.Domain.Test.Services;

/*
 * email in use
 * name in use
 */
public class UserRegisterServiceTest
{
    private UserRegisterService testObj = null!;
    private IUserRepo userRepo = null!;
    private IUserValidator userValidator = null!;

    [SetUp]
    public void SetUp()
    {
        userRepo = Substitute.For<IUserRepo>();
        userValidator = Substitute.For<IUserValidator>();

        testObj = new UserRegisterService(userRepo, userValidator);
    }
}