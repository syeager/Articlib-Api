using System.Net;
using Articlib.Core.Infra.Articles;
using AutoMapper;
using LittleByte.Extensions.AspNet.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Articlib.Core.Api.Articles;

public sealed class GetByIdArticleController : ArticleController
{
    private readonly IArticleReadRepo articleRepo;
    private readonly IMapper mapper;

    public GetByIdArticleController(IArticleReadRepo articleRepo, IMapper mapper)
    {
        this.articleRepo = articleRepo;
        this.mapper = mapper;
    }

    [HttpGet(Routes.FindById)]
    [ResponseType(HttpStatusCode.OK, typeof(ArticleDto))]
    [ResponseType(HttpStatusCode.NotFound)]
    public async Task<ApiResponse<ArticleDto>> Get(Guid id)
    {
        var article = await articleRepo.GetByIdAsync(id);
        var dto = mapper.Map<ArticleDto>(article);
        return new OkResponse<ArticleDto>(dto);
    }
}
