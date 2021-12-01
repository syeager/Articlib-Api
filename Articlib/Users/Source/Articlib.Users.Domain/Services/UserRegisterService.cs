using Articlib.Users.Domain.Models;
using Articlib.Users.Domain.Persistence;
using Articlib.Users.Domain.Validators;
using LittleByte.Validation;

namespace Articlib.Users.Domain.Services;

public interface IUserRegisterService
{
    ValidModel<User> Register(string email, string name);
}

internal class UserRegisterService : IUserRegisterService
{
    private readonly IUserRepo userRepo;
    private readonly IUserValidator userValidator;

    public UserRegisterService(IUserRepo userRepo, IUserValidator userValidator)
    {
        this.userRepo = userRepo;
        this.userValidator = userValidator;
    }

    public ValidModel<User> Register(string email, string name)
    {
        var user = User.Create(userValidator, email, name);
        userRepo.Add(user);
        return user;
    }
}