using Articlib.Core.Infra.Articles.Models;
using Articlib.Core.Infra.Users.Entities;
using Articlib.Core.Infra.Votes.Models;
using AutoMapper;
using LittleByte.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Articlib.Core.Infra.Persistence;

internal class CoreDb : DomainContext<CoreDb, UserDao, UserRole>
{
    [UsedImplicitly]
    public DbSet<ArticleDao> Articles { get; set; } = null!;

    [UsedImplicitly]
    public DbSet<VoteDao> Votes { get; set; } = null!;

    public CoreDb(IMapper mapper, DbContextOptions<CoreDb> options)
        : base(mapper, options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<VoteDao>().HasKey(k => new {k.ArticleId, k.UserId});
    }
}
