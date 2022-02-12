using LittleByte.Domain;

namespace Articlib.Core.Domain.Articles;

public sealed class ArticleTag
{
    public Id<Article> ArticleId { get; init; }
    public string Tag { get; init; } = null!;
    public uint Score { get; init; }

    public ArticleTag(Id<Article> articleId, string tag, uint score)
    {
        ArticleId = articleId;
        Tag = tag;
        Score = score;
    }
}
