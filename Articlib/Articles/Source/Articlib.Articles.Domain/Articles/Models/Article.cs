using Articlib.Articles.Domain.Users;
using LittleByte.Domain;
using LittleByte.Validation;

namespace Articlib.Articles.Domain.Articles;

public sealed class Article
{
    public Id<Article> Id { get; }
    public Uri Url { get; }
    public Id<User> PosterId { get; }
    public uint VoteCount { get; private set; }

    private Article(Id<Article> id, Uri url, Id<User> posterId)
    {
        Id = id;
        Url = url;
        PosterId = posterId;
    }

    public static Valid<Article> Create(
        IModelValidator<Article> articleValidator,
        Id<Article> id,
        Uri url,
        Id<User> posterId)
    {
        var article = new Article(id, url, posterId);
        var validArticle = articleValidator.Sign(article);
        return validArticle;
    }

    public void AddVote()
    {
        // TODO: Handle overflow.
        ++VoteCount;
    }
}
