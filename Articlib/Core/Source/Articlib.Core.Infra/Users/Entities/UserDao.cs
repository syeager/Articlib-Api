using LittleByte.Core.Objects;
using Microsoft.AspNetCore.Identity;

namespace Articlib.Core.Infra.Users.Entities;

internal class UserDao : IdentityUser<Guid>, IIdObject { }

internal class UserRole : IdentityRole<Guid> { }
