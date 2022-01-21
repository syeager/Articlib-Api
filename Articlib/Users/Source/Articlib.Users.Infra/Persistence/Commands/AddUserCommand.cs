using System.Diagnostics.CodeAnalysis;
using Articlib.Users.Domain.Commands;
using Articlib.Users.Domain.Models;
using AutoMapper;
using LittleByte.Validation;
using Microsoft.AspNetCore.Identity;

namespace Articlib.Users.Infra.Persistence.Commands;

[SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
internal class AddUserCommand : IAddUserCommand
{
    private readonly IMapper mapper;
    private readonly UserManager<UserDao> userManager;

    public AddUserCommand(IMapper mapper, UserManager<UserDao> userManager)
    {
        this.mapper = mapper;
        this.userManager = userManager;
    }

    public async Task AddAsync(Valid<User> user, Password password)
    {
        var domain = user.GetModelOrThrow();
        var entity = mapper.Map<UserDao>(domain);
        Log.Information("User {@User}", entity);

        var result = IdentityResult.Failed();
        try
        {
            result = await userManager.CreateAsync(entity, password.Value);
        }
        catch(Exception exception)
        {
            Log.Error(exception, "Failed to create user");
        }

        if(!result.Succeeded)
        {
            // TODO: Should this command return a result?
            throw new NotImplementedException();
        }
    }
}
