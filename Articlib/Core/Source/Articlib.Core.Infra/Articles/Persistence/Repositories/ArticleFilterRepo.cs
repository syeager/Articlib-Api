using Articlib.Core.Domain.Articles;
using AutoMapper;
using LittleByte.Infra.Models;
using Microsoft.EntityFrameworkCore;

namespace Articlib.Core.Infra.Articles;

public interface IArticleFilterRepo
{
    public Task<PageResponse<Article>> FilterAsync(PageRequest request);
}

internal class ArticleFilterRepo : IArticleFilterRepo
{
    private readonly ArticlesContext dbContext;
    private readonly IMapper mapper;

    public ArticleFilterRepo(ArticlesContext dbContext, IMapper mapper)
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