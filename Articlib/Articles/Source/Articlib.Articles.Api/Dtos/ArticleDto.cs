namespace Articlib.Articles.Api;

public class ArticleDto
{
    public Guid Id { get; init; }
    public Uri Url { get; init; } = null!;

    public ArticleDto() { }

    public ArticleDto(Guid id, Uri url)
    {
        Id = id;
        Url = url;
    }
}
