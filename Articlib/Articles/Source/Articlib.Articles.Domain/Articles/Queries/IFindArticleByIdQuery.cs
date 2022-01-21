using LittleByte.Domain;

namespace Articlib.Articles.Domain.Articles.Queries;

public interface IFindArticleByIdQuery
{
    Task<Article?> FindAsync(Id<Article> id);
}
