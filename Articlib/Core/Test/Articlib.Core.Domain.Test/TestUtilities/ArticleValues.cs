using Articlib.Core.Domain.Articles;
using LittleByte.Domain;
using LittleByte.Validation;

namespace Articlib.Core.Domain.Test;

internal static partial class TV
{
    public static class Articles
    {
        public static readonly Uri Url = new("https://www.test.com");

        public static Id<Article> Id() => Guid.NewGuid();

        public static Valid<Article> New(uint voteCount = 0)
        {
            var id = Id();

            return Article.Create(new SuccessModelValidator<Article>(), id, Url, voteCount, ArticleTags(id));
        }

        public static List<ArticleTag> ArticleTags(Id<Article> articleId) => new() {new (articleId, "dotnet", 1)};

        public static (Id<Article> id, List<ArticleTag> articleTags) IdAndArticleTags()
        {
            var id = Id();
            var articleTags = ArticleTags(id);
            return (id, articleTags);
        }
    }
}
