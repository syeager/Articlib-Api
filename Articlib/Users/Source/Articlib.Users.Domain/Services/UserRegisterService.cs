using Articlib.Users.Domain.Commands;

namespace Articlib.Users.Domain.Services;

public interface IUserRegisterService
{
    Task<Valid<User>> RegisterAsync(Email email, Name name, Password password);
}

public sealed class UserRegisterService : IUserRegisterService
{
    private readonly IAddUserCommand addUserCommand;
    private readonly IModelValidator<User> userValidator;

    public UserRegisterService(IAddUserCommand addUserCommand, IModelValidator<User> userValidator)
    {
        this.addUserCommand = addUserCommand;
        this.userValidator = userValidator;
    }

    // TODO: Confirm password.
    // TODO: Use password.
    // TODO: Check for existing user with email or name.
    public async Task<Valid<User>> RegisterAsync(Email email, Name name, Password password)
    {
        var id = Guid.NewGuid();
        var user = User.Create(userValidator, id, email, name);

        if(user.IsSuccess)
        {
            await addUserCommand.AddAsync(user, password);
        }

        return user;
    }
}
