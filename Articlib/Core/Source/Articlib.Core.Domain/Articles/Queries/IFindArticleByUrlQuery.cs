namespace Articlib.Core.Domain.Articles.Queries;

public interface IFindArticleByUrlQuery
{
    Task<Valid<Article>?> FindAsync(Uri url);
}
