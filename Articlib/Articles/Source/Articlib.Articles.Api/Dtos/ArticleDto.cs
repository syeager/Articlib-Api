namespace Articlib.Articles.Api;

public class ArticleDto
{
    public Guid Id { get; }
    public Uri Url { get; }

    public ArticleDto(Guid id, Uri url)
    {
        Id = id;
        Url = url;
    }
}
