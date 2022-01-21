using Articlib.Users.Domain.Models;
using Articlib.Users.Domain.Queries;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace Articlib.Users.Infra.Persistence.Queries;

internal sealed class FindUserByEmailAndPasswordQuery : IFindUserByEmailAndPasswordQuery
{
    private readonly IMapper mapper;
    private readonly UserManager<UserDao> userManager;

    public FindUserByEmailAndPasswordQuery(UserManager<UserDao> userManager, IMapper mapper)
    {
        this.userManager = userManager;
        this.mapper = mapper;
    }

    public async ValueTask<User?> TryFindAsync(Email email, Password password)
    {
        var userEntity = await userManager.FindByEmailAsync(email.Value);
        if(userEntity is null)
        {
            return null;
        }

        Log.Information("Found user by email {Email} with Id {Id}", email.Value, userEntity.Id);
        var correctPassword = await userManager.CheckPasswordAsync(userEntity, password.Value);

        if(correctPassword)
        {
            var user = mapper.Map<User>(userEntity);
            return user;
        }

        return null;
    }
}
