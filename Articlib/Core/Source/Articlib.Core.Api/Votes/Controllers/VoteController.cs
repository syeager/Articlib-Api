using Articlib.Core.Api.Votes.Requests;
using Articlib.Core.Domain.Articles;
using Articlib.Core.Domain.Users;
using LittleByte.Infra.Queries;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace Articlib.Core.Api.Votes.Controllers;

[Route("votes", Name = "Votes")]
[OpenApiTag("Votes")]
[ApiController]
public abstract class VoteController : Controller
{
    private readonly IFindByIdQuery<User> findUser;
    private readonly IFindByIdQuery<Article> findArticle;

    protected VoteController(IFindByIdQuery<User> findUser, IFindByIdQuery<Article> findArticle)
    {
        this.findUser = findUser;
        this.findArticle = findArticle;
    }

    protected async Task<(User user, Article article)> GetUserAndArticle(VoteRequest request)
    {
        var user = await findUser.FindRequiredAsync(request.UserId);
        var article = await findArticle.FindRequiredForEditAsync(request.ArticleId);
        return (user, article);
    }
}
