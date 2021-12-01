using Articlib.Users.Infra.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Articlib.Users.Infra.Persistence.Repositories;

internal class UserDb : DbContext
{
    [UsedImplicitly]
    public DbSet<UserDao> Users {get; set;} = null!;

    public UserDb(DbContextOptions<UserDb> options)
        : base(options)
    {
    }
}
