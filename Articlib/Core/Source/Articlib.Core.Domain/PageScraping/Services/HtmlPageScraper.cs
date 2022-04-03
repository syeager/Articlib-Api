using System.Web;
using Articlib.Core.Domain.PageScraping.Models;
using Articlib.Core.Domain.PageScraping.ProcessorTypes;
using HtmlAgilityPack;

namespace Articlib.Core.Domain.PageScraping.Services;

public interface IPageScraper
{
    PageMetadata ScrapePage(string pageContents);
}

internal class HtmlPageScraper : IPageScraper
{
    private readonly IReadOnlyCollection<IProcessor> titleProcessors;

    public HtmlPageScraper(IReadOnlyCollection<IProcessor> titleProcessors)
    {
        this.titleProcessors = titleProcessors;
    }

    public PageMetadata ScrapePage(string pageContents)
    {
        var htmlPage = CreateHtmlPage(pageContents);
        
        var title = Process(htmlPage, titleProcessors);

        var pageMetadata = new PageMetadata(title);
        return pageMetadata;
    }

    private static HtmlPage CreateHtmlPage(string pageContents)
    {
        var htmlDocument = new HtmlDocument();
        var html = HttpUtility.HtmlDecode(pageContents);
        htmlDocument.LoadHtml(html);
        var htmlPage = new HtmlPage(htmlDocument);
        return htmlPage;
    }

    private static string? Process(IPage page, IEnumerable<IProcessor> processors)
    {
        string? result = null;
        foreach(var processor in processors)
        {
            if(processor.TryProcess(page, out result))
            {
                break;
            }
        }

        return result;
    }
}
