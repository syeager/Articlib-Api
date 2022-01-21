using Articlib.Articles.Infra.Persistence.Daos;
using Microsoft.EntityFrameworkCore;

namespace Articlib.Articles.Infra.Persistence;

internal class ArticlesContext : DbContext
{
    [UsedImplicitly]
    public DbSet<ArticleDao> Articles { get; set; } = null!;

    [UsedImplicitly]
    public DbSet<VoteDao> Votes { get; set; } = null!;

    public ArticlesContext(DbContextOptions<ArticlesContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<VoteDao>().HasKey(k => new {k.ArticleId, k.UserId});
    }
}
