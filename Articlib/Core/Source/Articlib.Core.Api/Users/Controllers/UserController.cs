using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace Articlib.Core.Api.Users;

[Route("users", Name = "Users")]
[OpenApiTag("Users")]
[ApiController]
public abstract class UserController : Controller
{
}
