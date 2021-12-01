using LittleByte.Validation;

namespace Articlib.Core.Domain.Users;

public interface IUserRegisterService
{
    Valid<User> Register(string email, string name);
}

public class UserRegisterService : IUserRegisterService
{
    private readonly IUserRepo userRepo;
    private readonly IModelValidator<User> userValidator;

    public UserRegisterService(IUserRepo userRepo, IModelValidator<User> userValidator)
    {
        this.userRepo = userRepo;
        this.userValidator = userValidator;
    }

    public Valid<User> Register(string email, string name)
    {
        var id = Guid.NewGuid();
        var user = User.Create(userValidator, id, email, name);
        
        if (user.IsSuccess)
        {
            userRepo.Add(user);
        }
        return user;
    }
}