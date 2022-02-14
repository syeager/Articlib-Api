using LittleByte.Infra.Models;

namespace Articlib.Core.Infra.Articles.Models;

internal class ArticleDao : Entity
{
    public string Url { get; init; } = null!;
    public uint VoteCount { get; init; }
    public uint PostedCount { get; init; }
    public DateTime LastPostedDate { get; set; }

    public override string Identifier => Url;
}
