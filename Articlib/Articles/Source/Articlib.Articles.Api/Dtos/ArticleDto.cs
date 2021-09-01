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

    public static ArticleDto ToDto(Article article, IArticleReadRepo articleRepo)
    {
        var id = articleRepo.GetId(article);
        var articleDto = new ArticleDto(id, article.Url);
        return articleDto;
    }
}
