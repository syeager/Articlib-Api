using LittleByte.Domain;

namespace Articlib.Core.Domain.Articles.Queries;

public interface IFindArticleByIdQuery
{
    Task<Article?> FindAsync(Id<Article> id);
}
