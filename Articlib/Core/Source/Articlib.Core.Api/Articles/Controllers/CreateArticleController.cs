using System.ComponentModel;
using System.Net;
using Articlib.Core.Domain.Articles;
using Articlib.Core.Infra.Articles;
using AutoMapper;
using LittleByte.Extensions.AspNet.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Articlib.Core.Api.Articles;

[Authorize]
public sealed class CreateArticleController : ArticleController
{
    private readonly IArticleReadRepo articleRepo;
    private readonly IMapper mapper;
    private readonly IArticleCreateService articleCreateService;

    public CreateArticleController(IArticleReadRepo articleRepo, IMapper mapper, IArticleCreateService articleCreateService)
    {
        this.articleRepo = articleRepo;
        this.mapper = mapper;
        this.articleCreateService = articleCreateService;
    }

    [HttpPost("create")]
    [LittleByte.Extensions.AspNet.Responses.ResponseType(HttpStatusCode.BadRequest)]
    [LittleByte.Extensions.AspNet.Responses.ResponseType(HttpStatusCode.Created, typeof(ArticleDto))]
    public async Task<ApiResponse<ArticleDto>> Create(ArticleCreateRequest request)
    {
        var validArticle = articleCreateService.Create(new Uri(request.Url), request.PosterId);
        var article = validArticle.GetModelOrThrow();
        await articleRepo.SaveChangesAsync();
        var dto = mapper.Map<ArticleDto>(article);
        return new CreatedResponse<ArticleDto>(dto);
    }
}
