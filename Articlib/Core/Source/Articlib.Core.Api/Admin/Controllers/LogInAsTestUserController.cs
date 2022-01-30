using Articlib.Core.Api.Articles;
using Articlib.Core.Api.Users;
using Articlib.Core.Api.Users.Responses;
using LittleByte.Extensions.AspNet.Extensions;
using LittleByte.Extensions.AspNet.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Articlib.Core.Api.Admin.Controllers;

public sealed class LogInAsTestUserController : AdminController
{
    private readonly LogInController logInController;

    public LogInAsTestUserController(LogInController logInController)
    {
        this.logInController = logInController;
    }

    [HttpPost("log-in")]
    public async Task<ApiResponse<LogInResponse>> LogIn()
    {
        var request = new LogInRequest("test@articlib.com", "abc");
        var result = await logInController.LogIn(request);
        return result;
    }
}

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
        for(int i = 0; i < count; i++)
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
