using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Articlib.Users.Infra.Persistence;

internal class UsersContext : IdentityDbContext<UserDao, UserRole, Guid>
{
    public UsersContext(DbContextOptions<UsersContext> options)
        : base(options) { }
}
