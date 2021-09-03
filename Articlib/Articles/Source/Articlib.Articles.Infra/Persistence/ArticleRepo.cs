using AutoMapper;
using LittleByte.Core.Exceptions;
using LittleByte.Validation;

namespace Articlib.Articles.Infra;

public interface IArticleReadRepo
{
    public Task<Article> GetByIdAsync(Guid id);
}

public interface IArticleWriteRepo : IArticleReadRepo
{
    public Task<Article> CreateAsync(ValidModel<Article> article);
}

internal sealed class ArticleRepo : IArticleWriteRepo
{
    private readonly ArticleDb articleDb;
    private readonly IMapper mapper;
    private readonly IEntityIdWriteCache modelIdCache;

    public ArticleRepo(ArticleDb articleDb, IMapper mapper, IEntityIdWriteCache modelIdCache)
    {
        this.articleDb = articleDb;
        this.mapper = mapper;
        this.modelIdCache = modelIdCache;
    }

    public async Task<Article> CreateAsync(ValidModel<Article> article)
    {
        var domain = article.GetModelOrThrow();
        var dao = CreateDao(domain);
        articleDb.Add(dao);

        //await articleDb.SaveChangesAsync();
        await Task.CompletedTask;

        return domain;
    }

    public async Task<Article> GetByIdAsync(Guid id)
    {
        var dao = await articleDb.FindAsync<ArticleDao>(id);
        if(dao == null)
        {
            throw new NotFoundException(typeof(Article), id);
        }

        var article = mapper.Map<Article>(dao);
        return article;
    }

    private ArticleDao CreateDao(Article domain)
    {
        modelIdCache.Add(domain.Url.AbsoluteUri, Guid.NewGuid());
        var dao = mapper.Map<ArticleDao>(domain);
        modelIdCache.Add(dao);
        return dao;
    }
}
