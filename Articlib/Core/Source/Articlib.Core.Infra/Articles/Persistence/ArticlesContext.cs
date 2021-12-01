﻿using Microsoft.EntityFrameworkCore;

namespace Articlib.Core.Infra.Articles;

internal class ArticlesContext : DbContext
{
    [UsedImplicitly]
    public DbSet<ArticleDao> Articles { get; set; } = null!;

    public ArticlesContext(DbContextOptions<ArticlesContext> options)
        : base(options)
    {
    }
}
