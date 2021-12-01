using Microsoft.EntityFrameworkCore;

namespace Articlib.Core.Infra.Users;

internal class UserDb : DbContext
{
    [UsedImplicitly]
    public DbSet<UserDao> Users {get; set;} = null!;

    public UserDb(DbContextOptions<UserDb> options)
        : base(options)
    {
    }
}
