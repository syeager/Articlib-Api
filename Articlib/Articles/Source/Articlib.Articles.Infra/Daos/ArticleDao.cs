using LittleByte.Infra.Models;

namespace Articlib.Articles.Infra;

internal class ArticleDao : Entity
{
    public string Url { get; init; } = null!;

    public override string Identifier => Url;
}
