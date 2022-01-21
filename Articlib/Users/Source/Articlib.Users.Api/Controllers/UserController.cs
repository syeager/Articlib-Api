using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace Articlib.Users.Api.Controllers;

[Route("users", Name = "Users")]
[OpenApiTag("Users")]
[ApiController]
public abstract class UserController : Controller { }
