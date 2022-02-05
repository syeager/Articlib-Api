using Articlib.Core.Api.Articles;
using LittleByte.Extensions.AspNet.Extensions;
using LittleByte.Extensions.AspNet.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Articlib.Core.Api.Admin.Controllers;

public sealed class PostArticleController : AdminController
{
    private readonly CreateArticleController createArticleController;

    public PostArticleController(CreateArticleController createArticleController)
    {
        this.createArticleController = createArticleController;
    }

    [HttpPost("article")]
    public async Task<ApiResponse<List<ArticleDto>>> PostArticle(int count = 1)
    {
        AsTestUserIfMissingAuth();

        var articles = new List<ArticleDto>(count);
        for(var i = 0; i < count; i++)
        {
            var request = new ArticleCreateRequest
            {
                PosterId = HttpContext.GetUserId()!.Value,
                Url = $"https://www.google.com/{Guid.NewGuid()}",
            };
            var result = await createArticleController.Create(request);
            articles.Add(result.Obj!);
        }

        return new OkResponse<List<ArticleDto>>(articles);
    }
}
