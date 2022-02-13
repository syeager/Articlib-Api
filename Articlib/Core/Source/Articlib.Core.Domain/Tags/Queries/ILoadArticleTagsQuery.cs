using Articlib.Core.Domain.Articles;
using LittleByte.Domain;

namespace Articlib.Core.Domain.Tags.Queries;

public interface ILoadArticleTagsQuery
{
    Task<IReadOnlyCollection<ArticleTag>> LoadAsync(Id<Article> articleId);
}
