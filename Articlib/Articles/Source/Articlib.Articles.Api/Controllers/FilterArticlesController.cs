using System.Net;
using Articlib.Articles.Infra.Persistence.Queries;
using AutoMapper;
using LittleByte.Extensions.AspNet.Responses;
using LittleByte.Infra.Models;
using Microsoft.AspNetCore.Mvc;

namespace Articlib.Articles.Api;

public sealed class FilterArticlesController : ArticleController
{
    private readonly IFilterArticlesQuery articlesQuery;
    private readonly IMapper mapper;

    public FilterArticlesController(IFilterArticlesQuery articlesQuery, IMapper mapper)
    {
        this.articlesQuery = articlesQuery;
        this.mapper = mapper;
    }

    [HttpGet("filter")]
    [ResponseType(HttpStatusCode.OK, typeof(PageResponse<ArticleDto>))]
    public async Task<ApiResponse<PageResponse<ArticleDto>>> Filter([FromQuery] PageRequest request)
    {
        var articles = await articlesQuery.FilterAsync(request);
        var dtos = articles.CastResults(mapper.Map<ArticleDto>);
        return new OkResponse<PageResponse<ArticleDto>>(dtos);
    }
}
