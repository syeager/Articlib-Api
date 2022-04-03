using System.Diagnostics.CodeAnalysis;
using Articlib.Core.Domain.PageScraping.Models;

namespace Articlib.Core.Domain.PageScraping.ProcessorTypes;

internal abstract class ValueProcessor : IProcessor
{
    private readonly string name;

    protected ValueProcessor(string name)
    {
        this.name = name;
    }

    public bool TryProcess(IPage page, [NotNullWhen(true)] out string? result)
    {
        var node = page.SelectNode(name);
        result = node?.Value;
        return !string.IsNullOrWhiteSpace(result);
    }
}
