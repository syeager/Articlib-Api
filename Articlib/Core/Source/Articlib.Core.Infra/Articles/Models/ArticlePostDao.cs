using Articlib.Core.Infra.Users.Entities;

namespace Articlib.Core.Infra.Articles.Models;

internal sealed class ArticlePostDao
{
    public Guid UserId { get; init; }
    public Guid ArticleId { get; init; }
    public DateTime PostDate { get; init; }

    public UserDao? User { get; set; }
    public ArticleDao? Article { get; set; }
}
