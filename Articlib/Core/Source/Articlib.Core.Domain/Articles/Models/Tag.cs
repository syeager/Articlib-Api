namespace Articlib.Core.Domain.Articles;

public sealed class Tag
{
    public string Name { get; init; }

    public Tag(string name)
    {
        Name = name;
    }
}
