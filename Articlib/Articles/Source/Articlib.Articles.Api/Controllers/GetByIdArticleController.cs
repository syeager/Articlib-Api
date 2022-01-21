using System.Net;
using Articlib.Core.Domain;
using AutoMapper;
using LittleByte.Core.Exceptions;
using LittleByte.Extensions.AspNet.Responses;
using LittleByte.Infra.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Articlib.Articles.Api;

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
        //var article = await findByIdQuery.FindAsync(id.ToString());
        var article = await findByIdQuery.FindAsync(id);
        if(article is null)
        {
            throw new NotFoundException(typeof(Article), id);
        }

        var dto = mapper.Map<ArticleDto>(article);
        return new OkResponse<ArticleDto>(dto);
    }
}
