using LittleByte.Core.Exceptions;
using LittleByte.Validation;

namespace Articlib.Articles.Infra.Persistence;

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

    public ArticleRepo(ArticleDb articleDb)
    {
        this.articleDb = articleDb;
    }

    public async Task<Article> CreateAsync(ValidModel<Article> article)
    {
        var domain = article.GetModelOrThrow();
        var dao = ArticleDao.FromDomain(domain);
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

        var article = ArticleDao.ToDomain(dao);
        return article;
    }
}
