using HtmlAgilityPack;

namespace Articlib.Core.Domain.PageScraping.Models;

internal interface IPage
{
    PageNode? SelectNode(string nodeType);
}

internal class HtmlPage : IPage
{
    private readonly HtmlDocument html;

    public HtmlPage(HtmlDocument html)
    {
        this.html = html;
    }

    public PageNode? SelectNode(string nodeType)
    {
        var htmlNode = html.DocumentNode.SelectSingleNode($"//{nodeType}");

        if(htmlNode is null)
        {
            return null;
        }

        var pageNode = new PageNode(htmlNode.InnerText);
        return pageNode;
    }
}

internal record PageNode(string Value);
