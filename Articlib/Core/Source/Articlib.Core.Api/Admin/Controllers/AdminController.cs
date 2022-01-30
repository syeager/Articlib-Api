using System.Security.Claims;
using LittleByte.Extensions.AspNet.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using NSwag.Annotations;

namespace Articlib.Core.Api.Admin.Controllers;

[Route("admin", Name = "Admin")]
[OpenApiTag("Admin")]
[ApiController]
public abstract class AdminController : Controller
{
    protected void AsTestUserIfMissingAuth()
    {
        if(HttpContext.GetUserId() == null)
        {
            // log
            var user = new ClaimsPrincipal();
            var claim = new Claim(JwtRegisteredClaimNames.NameId, "99999999-9999-9999-9999-999999999999");
            user.AddIdentity(new(new[] {claim}));

            HttpContext.User = user;
        }
    }
}
