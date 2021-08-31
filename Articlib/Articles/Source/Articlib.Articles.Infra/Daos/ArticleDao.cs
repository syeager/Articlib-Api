namespace Articlib.Articles.Infra;

internal class ArticleDao
{
    public Guid Id { get; set; }
    public string Url { get; set; } = null!;

    internal static ArticleDao FromDomain(Article article, Guid id)
    {
        var dao = new ArticleDao
        {
            Id = id,
            Url = article.Url.AbsoluteUri,
        };
        return dao;
    }

    internal static Article ToDomain(ArticleDao dao)
    {
        var url = new Uri(dao.Url);
        var domain = Article.Create(url).GetModelOrThrow();
        return domain;
    }
}

