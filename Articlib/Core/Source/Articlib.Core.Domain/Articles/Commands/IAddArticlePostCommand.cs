using Articlib.Core.Domain.Users;

namespace Articlib.Core.Domain.Articles;

public interface IAddArticlePostCommand
{
    void Add(ArticlePost post);
}
