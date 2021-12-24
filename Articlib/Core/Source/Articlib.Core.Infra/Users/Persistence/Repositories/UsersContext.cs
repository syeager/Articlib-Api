using Microsoft.EntityFrameworkCore;

namespace Articlib.Core.Infra.Users;

internal class UsersContext : DbContext
{
    [UsedImplicitly] public DbSet<UserDao> Users { get; set; } = null!;
   
    public UsersContext(DbContextOptions<UsersContext> options)
        : base(options)
    {
    }
}