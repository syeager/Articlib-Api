using LittleByte.Infra.Models;

namespace Articlib.Core.Infra.Articles.Models;

internal class ArticleDao : Entity
{
    public string Url { get; init; } = null!;
    public uint VoteCount { get; init; }

    public override string Identifier => Url;
}
