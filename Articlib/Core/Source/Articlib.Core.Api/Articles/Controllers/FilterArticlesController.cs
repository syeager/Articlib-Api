using System.Net;
using Articlib.Core.Infra.Articles;
using AutoMapper;
using LittleByte.Extensions.AspNet.Responses;
using LittleByte.Infra.Models;
using Microsoft.AspNetCore.Mvc;

namespace Articlib.Core.Api.Articles;

public sealed class FilterArticlesController : ArticleController
{
    private readonly IArticleFilterRepo articleRepo;
    private readonly IMapper mapper;

    public FilterArticlesController(IArticleFilterRepo articleRepo, IMapper mapper)
    {
        this.articleRepo = articleRepo;
        this.mapper = mapper;
    }

    [HttpGet("filter")]
    [ResponseType(HttpStatusCode.OK, typeof(PageResponse<ArticleDto>))]
    public async Task<ApiResponse<PageResponse<ArticleDto>>> Filter([FromQuery] PageRequest request)
    {
        var articles = await articleRepo.FilterAsync(request);
        var dtos = articles.CastResults(mapper.Map<ArticleDto>);
        return new OkResponse<PageResponse<ArticleDto>>(dtos);
    }
}