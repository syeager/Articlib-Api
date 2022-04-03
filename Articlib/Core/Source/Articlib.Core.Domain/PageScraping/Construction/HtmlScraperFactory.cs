using Articlib.Core.Domain.PageScraping.Processors;
using Articlib.Core.Domain.PageScraping.Services;

namespace Articlib.Core.Domain.PageScraping.Construction;

internal class HtmlScraperFactory
{
    public HtmlPageScraper Create()
    {
        return new ScraperBuilder()
            .AddTitleProcessor(new TitleValueProcessor())
            .BuildHtmlScraper();
    }
}
