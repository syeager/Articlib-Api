using LittleByte.Domain;

namespace Articlib.Core.Domain.Articles;

public sealed class ArticleTag
{
    public Id<Article> ArticleId { get; init; }
    public string TagName { get; init; }
    public uint Score { get; init; }

    public ArticleTag(Id<Article> articleId, string tagName, uint score)
    {
        ArticleId = articleId;
        TagName = tagName;
        Score = score;
    }
}
