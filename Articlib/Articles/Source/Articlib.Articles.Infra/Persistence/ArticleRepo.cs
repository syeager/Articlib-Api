using AutoMapper;
using LittleByte.Core.Exceptions;
using LittleByte.Validation;

namespace Articlib.Articles.Infra;

public interface IArticleReadRepo
{
    public Task<Article> GetByIdAsync(Guid id);
    Guid GetId(Article article);
}

public interface IArticleWriteRepo : IArticleReadRepo
{
    public Task<Article> CreateAsync(ValidModel<Article> article);
}

internal sealed class ArticleRepo : IArticleWriteRepo
{
    private readonly ArticleDb articleDb;
    private readonly IMapper mapper;

    public ArticleRepo(ArticleDb articleDb, IMapper mapper)
    {
        this.articleDb = articleDb;
        this.mapper = mapper;
    }

    public async Task<Article> CreateAsync(ValidModel<Article> article)
    {
        var domain = article.GetModelOrThrow();
        var dao = mapper.Map<ArticleDao>(domain);
        articleDb.Add(dao);
        await articleDb.SaveChangesAsync();
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

    public Guid GetId(Article article)
    {
        var dao = articleDb.ChangeTracker.Entries<ArticleDao>().FirstOrDefault();
        var id = dao?.Entity.Id ?? Guid.NewGuid();
        return id;
    }
}
