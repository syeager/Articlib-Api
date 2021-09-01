﻿using LittleByte.Core.Exceptions;
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

    public ArticleRepo(ArticleDb articleDb)
    {
        this.articleDb = articleDb;
    }

    public async Task<Article> CreateAsync(ValidModel<Article> article)
    {
        var domain = article.GetModelOrThrow();
        var dao = ArticleDao.FromDomain(domain, Guid.NewGuid());
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

    public Guid GetId(Article article)
    {
        var dao = articleDb.ChangeTracker.Entries<ArticleDao>().First();
        return dao.Entity.Id;
    }
}
