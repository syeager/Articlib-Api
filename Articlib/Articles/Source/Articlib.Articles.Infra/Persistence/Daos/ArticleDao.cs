using LittleByte.Infra.Models;

namespace Articlib.Articles.Infra.Persistence.Daos;

internal class ArticleDao : Entity
{
    public Guid PosterId { get; init; }
    public string Url { get; init; } = null!;

    public override string Identifier => Url;
}
