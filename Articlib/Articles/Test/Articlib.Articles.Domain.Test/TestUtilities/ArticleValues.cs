using Articlib.Articles.Domain.Articles;
using LittleByte.Domain;
using LittleByte.Validation;

namespace Articlib.Articles.Domain.Test;

internal static partial class TV
{
    public static class Articles
    {
        public static readonly Uri Url = new("https://www.test.com");

        public static Article Valid() => Article.Create(new SuccessModelValidator<Article>(), Id(), Url, Users.Id())
            .GetModelOrThrow();

        public static Id<Article> Id() => Guid.NewGuid();
    }
}
