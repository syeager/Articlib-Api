namespace Articlib.Articles.Infra;

internal interface IEntity
{
    public Guid Id { get; }
    public string Identifier { get; }
}
