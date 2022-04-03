using System.Diagnostics.CodeAnalysis;
using Articlib.Core.Domain.PageScraping.Models;

namespace Articlib.Core.Domain.PageScraping.ProcessorTypes;

public interface IProcessor
{
    bool TryProcess(IPage page, [NotNullWhen(true)] out string? result);
}
