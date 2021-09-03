namespace Articlib.Articles.Infra;

internal abstract class Entity : IEntity
{
    public Guid Id { get; set; }

    public abstract string Identifier { get; }
}

internal class ArticleDao : Entity
{
    public string Url { get; set; } = null!;

    public override string Identifier => Url;
}
