namespace Articlib.Core.Domain.Tags.Models;

public sealed class Tag
{
    public string Name { get; init; }

    public Tag(string name)
    {
        Name = name;
    }
}
