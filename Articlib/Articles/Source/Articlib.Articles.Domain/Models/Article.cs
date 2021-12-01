using LittleByte.Validation;

namespace Articlib.Articles.Domain;

public class Article
{
    public Uri Url { get; }

    private Article(Uri url)
    {
        Url = url;
    }

    public static ValidModel<Article> Create(IArticleValidator articleValidator, Uri url)
    {
        var article = new Article(url);
        var validArticle = articleValidator.Sign(article);

        return validArticle;
    }
}
