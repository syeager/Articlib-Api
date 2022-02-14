using Articlib.Core.Domain.Articles;
using Articlib.Core.Infra.Persistence;
using AutoMapper;
using LittleByte.Extensions.AutoMapper;
using LittleByte.Infra.Models;
using LittleByte.Validation;
using Microsoft.EntityFrameworkCore;

namespace Articlib.Core.Infra.Articles.Queries;

public interface IFilterArticlesQuery
{
    public Task<PageResponse<Article>> FilterAsync(PageRequest request);
}

internal class FilterQuery : IFilterArticlesQuery
{
    private readonly CoreDb coreDb;
    private readonly IMapper mapper;

    public FilterQuery(CoreDb coreDb, IMapper mapper)
    {
        this.coreDb = coreDb;
        this.mapper = mapper;
    }

    public async Task<PageResponse<Article>> FilterAsync(PageRequest request)
    {
        // TODO: Use pagination.
        var entities = await coreDb.Articles.ToArrayAsync();
        var articles = mapper.MapRange<Valid<Article>>(entities).Select(a => a.GetModelOrThrow()).ToList();
        var response = new PageResponse<Article>(10, 0, 1, articles.Count, articles);
        return response;
    }
}
