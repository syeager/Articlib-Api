using System.Diagnostics.CodeAnalysis;
using Articlib.Core.Infra.Articles.Models;
using Articlib.Core.Infra.Users.Entities;
using Articlib.Core.Infra.Votes.Models;
using AutoMapper;
using LittleByte.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Articlib.Core.Infra.Persistence;

[SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Global")]
internal class CoreDb : DomainContext<CoreDb, UserDao, UserRole>
{
    public DbSet<ArticleDao> Articles { get; set; } = null!;
    public DbSet<ArticlePostDao> ArticlePosts { get; set; } = null!;
    public DbSet<VoteDao> Votes { get; set; } = null!;

    public CoreDb(IMapper mapper, DbContextOptions<CoreDb> options)
        : base(mapper, options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<VoteDao>().HasKey(v => new {v.ArticleId, v.UserId});
        modelBuilder.Entity<ArticlePostDao>().HasKey(ap => new {ap.UserId, ap.ArticleId});
    }
}
