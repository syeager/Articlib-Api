using Articlib.Core.Domain.PageScraping.ProcessorTypes;

namespace Articlib.Core.Domain.PageScraping.Processors;

internal sealed class TitleValueProcessor : ValueProcessor
{
    public TitleValueProcessor() : base("title") { }
}
