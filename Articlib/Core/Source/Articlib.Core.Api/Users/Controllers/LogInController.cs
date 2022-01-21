using System.Net;
using Articlib.Core.Api.Users.Responses;
using Articlib.Core.Domain.Users;
using AutoMapper;
using LittleByte.Core.Exceptions;
using LittleByte.Extensions.AspNet.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Articlib.Core.Api.Users;

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
    [ResponseType(HttpStatusCode.OK, typeof(LogInResponse))]
    [ResponseType(HttpStatusCode.BadRequest)]
    public async Task<ApiResponse<LogInResponse>> LogIn(LogInRequest request)
    {
        var email = new Email(request.Email);
        var password = new Password(request.Password);

        var result = await logInService.LogInAsync(email, password);
        if(!result.Succeeded)
        {
            throw new BadRequestException("Email or Password is incorrect.");
        }

        var response = mapper.Map<LogInResponse>(result);
        return new OkResponse<LogInResponse>(response);
    }
}
