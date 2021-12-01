using Microsoft.EntityFrameworkCore;

namespace Articlib.Articles.Infra;

internal class ArticleDb : DbContext
{
    public DbSet<ArticleDao> Articles { get; set; } = null!;

    public ArticleDb(DbContextOptions<ArticleDb> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}
