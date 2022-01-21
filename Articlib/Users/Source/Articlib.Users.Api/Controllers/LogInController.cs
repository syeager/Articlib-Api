using Articlib.Users.Api.Requests;
using Articlib.Users.Api.Responses;
using Articlib.Users.Domain.Models;
using Articlib.Users.Domain.Services;
using AutoMapper;
using LittleByte.Extensions.AspNet.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Articlib.Users.Api.Controllers;

public sealed class LogInController : UserController
{
    private readonly ILogInService logInService;
    private readonly IMapper mapper;

    public LogInController(ILogInService logInService, IMapper mapper)
    {
        this.logInService = logInService;
        this.mapper = mapper;
    }

    [HttpPost("log-in")]
    public async Task<ApiResponse<LogInResponse>> LogIn(LogInRequest request)
    {
        var email = new Email(request.Email);
        var password = new Password(request.Password);

        var result = await logInService.LogInAsync(email, password);

        var response = mapper.Map<LogInResponse>(result);
        return new OkResponse<LogInResponse>(response);
    }
}
