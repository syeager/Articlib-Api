using Articlib.Core.Domain.PageScraping.ProcessorTypes;
using Articlib.Core.Domain.PageScraping.Services;

namespace Articlib.Core.Domain.PageScraping.Construction;

internal class ScraperBuilder
{
    private readonly List<IProcessor> titles = new();

    public ScraperBuilder AddTitleProcessor(IProcessor processor) => Add(processor, titles);

    public HtmlPageScraper BuildHtmlScraper() => new(titles);

    private ScraperBuilder Add(IProcessor processor, ICollection<IProcessor> processors)
    {
        processors.Add(processor);
        return this;
    }
}
