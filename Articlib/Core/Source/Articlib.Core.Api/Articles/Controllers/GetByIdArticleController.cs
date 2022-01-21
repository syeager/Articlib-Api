using System.Net;
using Articlib.Core.Domain.Articles;
using AutoMapper;
using LittleByte.Extensions.AspNet.Responses;
using LittleByte.Infra.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Articlib.Core.Api.Articles;

public sealed class GetByIdArticleController : ArticleController
{
    private readonly IFindByIdQuery<Article> findByIdQuery;
    private readonly IMapper mapper;

    public GetByIdArticleController(IFindByIdQuery<Article> findByIdQuery, IMapper mapper)
    {
        this.findByIdQuery = findByIdQuery;
        this.mapper = mapper;
    }

    [HttpGet(Routes.FindById)]
    [ResponseType(HttpStatusCode.OK, typeof(ArticleDto))]
    [ResponseType(HttpStatusCode.NotFound)]
    public async Task<ApiResponse<ArticleDto>> Get(Guid id)
    {
        var article = await findByIdQuery.FindRequiredAsync(id);
        var dto = mapper.Map<ArticleDto>(article);
        return new OkResponse<ArticleDto>(dto);
    }
}
