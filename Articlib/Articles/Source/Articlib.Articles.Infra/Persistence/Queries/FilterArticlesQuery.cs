using Articlib.Articles.Domain.Articles;
using AutoMapper;
using LittleByte.Infra.Models;
using Microsoft.EntityFrameworkCore;

namespace Articlib.Articles.Infra.Persistence.Queries;

public interface IFilterArticlesQuery
{
    public Task<PageResponse<Article>> FilterAsync(PageRequest request);
}

internal class FilterQuery : IFilterArticlesQuery
{
    private readonly ArticlesContext dbContext;
    private readonly IMapper mapper;

    public FilterQuery(ArticlesContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }

    public async Task<PageResponse<Article>> FilterAsync(PageRequest request)
    {
        // TODO: Use pagination.
        var entities = await dbContext.Articles.ToArrayAsync();
        var articles = entities.Select(a => mapper.Map<Article>(a)).ToList();
        var response = new PageResponse<Article>(10, 0, 1, articles.Count, articles);
        return response;
    }
}
