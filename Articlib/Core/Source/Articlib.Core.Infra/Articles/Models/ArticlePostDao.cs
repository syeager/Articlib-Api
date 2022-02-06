namespace Articlib.Core.Infra.Articles.Models;

public sealed class ArticlePostDao
{
    public Guid UserId { get; set; }
    public Guid ArticleId { get; set; }
    public DateTime PostDate { get; set; }
}
