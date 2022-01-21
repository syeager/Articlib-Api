using LittleByte.Core.Objects;
using Microsoft.AspNetCore.Identity;

namespace Articlib.Users.Infra.Persistence.Entities;

internal class UserDao : IdentityUser<Guid>, IIdObject { }

internal class UserRole : IdentityRole<Guid> { }
