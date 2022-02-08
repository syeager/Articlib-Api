using Articlib.Core.Domain.Articles;
using LittleByte.Domain;
using LittleByte.Validation;

namespace Articlib.Core.Domain.Test;

internal static partial class TV
{
    public static class Articles
    {
        public static readonly Uri Url = new("https://www.test.com");

        public static Valid<Article> Valid() => Article.Create(new SuccessModelValidator<Article>(), Id(), Url, 0);

        public static Id<Article> Id() => Guid.NewGuid();
    }
}
