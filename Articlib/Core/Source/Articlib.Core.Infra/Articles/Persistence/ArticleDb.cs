using Articlib.Core.Infra.Articles.Daos;
using Microsoft.EntityFrameworkCore;

namespace Articlib.Core.Infra.Articles;

internal class ArticleDb : DbContext
{
    [UsedImplicitly]
    public DbSet<ArticleDao> Articles { get; set; } = null!;

    public ArticleDb(DbContextOptions<ArticleDb> options)
        : base(options)
    {
    }
}
