using Articlib.Core.Domain.Users;
using Articlib.Core.Domain.Users.Queries;
using Articlib.Core.Infra.Users.Entities;
using AutoMapper;
using LittleByte.Validation;
using Microsoft.AspNetCore.Identity;

namespace Articlib.Core.Infra.Users.Queries;

internal sealed class FindUserByEmailAndPasswordQuery : IFindUserByEmailAndPasswordQuery
{
    private readonly IMapper mapper;
    private readonly UserManager<UserDao> userManager;

    public FindUserByEmailAndPasswordQuery(UserManager<UserDao> userManager, IMapper mapper)
    {
        this.userManager = userManager;
        this.mapper = mapper;
    }

    public async ValueTask<Valid<User>?> TryFindAsync(Email email, Password password)
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
            var user = mapper.Map<Valid<User>>(userEntity);
            return user;
        }

        return null;
    }
}
