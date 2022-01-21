using System.Net;
using Articlib.Users.Api.Requests;
using Articlib.Users.Api.Responses;
using Articlib.Users.Domain.Models;
using Articlib.Users.Domain.Services;
using AutoMapper;
using LittleByte.Extensions.AspNet.Responses;
using LittleByte.Infra.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Articlib.Users.Api.Controllers;

public sealed class CreateUserController : UserController
{
    private readonly ILogInService logIn;
    private readonly IMapper mapper;
    private readonly IUserRegisterService register;
    private readonly ISaveContextCommand saveContextCommand;

    public CreateUserController(
        IMapper mapper,
        IUserRegisterService register,
        ILogInService logIn,
        ISaveContextCommand saveContextCommand)
    {
        this.mapper = mapper;
        this.register = register;
        this.logIn = logIn;
        this.saveContextCommand = saveContextCommand;
    }

    [HttpPost("create")]
    [ResponseType(HttpStatusCode.OK, typeof(LogInResponse))]
    [ResponseType(HttpStatusCode.BadRequest)]
    public async Task<ApiResponse<LogInResponse>> Create(UserRegisterRequest request)
    {
        var email = new Email(request.Email);
        var name = new Name(request.Name);
        var password = new Password(request.Password);

        await RegisterAsync(email, name, password);
        var response = await LogInAsync(email, password);
        await saveContextCommand.CommitChangesAsync();

        return new OkResponse<LogInResponse>(response);
    }

    private async Task RegisterAsync(Email email, Name name, Password password)
    {
        var user = await register.RegisterAsync(email, name, password);
        if(!user.IsSuccess)
        {
            throw new NotImplementedException();
        }
    }

    private async Task<LogInResponse> LogInAsync(Email email, Password password)
    {
        var logInResult = await logIn.LogInAsync(email, password);
        if(!logInResult.Succeeded)
        {
            throw new NotImplementedException();
        }

        var response = mapper.Map<LogInResponse>(logInResult);
        return response;
    }
}
