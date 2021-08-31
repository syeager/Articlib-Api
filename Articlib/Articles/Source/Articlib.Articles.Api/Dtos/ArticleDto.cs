using Articlib.Articles.Domain;

namespace Articlib.Articles.Api;

public class ArticleDto
{
    public Guid Id { get; }
    public Uri Url { get; }

    private ArticleDto(Guid id, Uri url)
    {
        Id = id;
        Url = url;
    }
    
    public static ArticleDto ToDto(Article article)
    {
        var articleDto = new ArticleDto(Guid.Empty, article.Url);
        return articleDto;
    }
}
