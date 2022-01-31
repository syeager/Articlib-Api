using Articlib.Core.Api.Users;
using Articlib.Core.Api.Users.Responses;
using LittleByte.Extensions.AspNet.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Articlib.Core.Api.Admin.Controllers;

public sealed class LogInAsTestUserController : AdminController
{
    private readonly LogInController logInController;

    public LogInAsTestUserController(LogInController logInController)
    {
        this.logInController = logInController;
    }

    [HttpPost("log-in")]
    public async Task<ApiResponse<LogInResponse>> LogIn()
    {
        var request = new LogInRequest("test@articlib.com", "abc");
        var result = await logInController.LogIn(request);
        return result;
    }
}
