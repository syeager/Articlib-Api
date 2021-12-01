using System;
using LittleByte.Validation;

namespace Articlib.Articles.Domain;

public class Article
{
    public Uri Url { get; }

    private Article(Uri url)
    {
        Url = url;
    }

    public static ValidModel<Article> Create(Uri url)
    {
        var article = new Article(url);
        var validArticle = new ArticleValidator().Sign(article);

        return validArticle;
    }
}
