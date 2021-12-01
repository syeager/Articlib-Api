using AutoMapper;
using LittleByte.Core.Exceptions;
using LittleByte.Infra;
using LittleByte.Validation;

namespace Articlib.Articles.Infra;

public interface IArticleReadRepo : IRepo
{
    public Task<Article> GetByIdAsync(Guid id);
}

public interface IArticleWriteRepo : IArticleReadRepo
{
    public Article Add(ValidModel<Article> article);
}

internal sealed class ArticleRepo : Repo<ArticleDb>, IArticleWriteRepo
{
    public ArticleRepo(ArticleDb dbContext, IMapper mapper, IEntityIdWriteCache modelIdCache)
        : base(dbContext, mapper, modelIdCache)
    {
    }

    public Article Add(ValidModel<Article> article)
    {
        using var context = Logs.Props();
        var domain = article.GetModelOrThrow();
        var dao = CreateDao(domain);
        logger.Information("Created article");
        dbContext.Add(dao);

        return domain;
    }

    public async Task<Article> GetByIdAsync(Guid id)
    {
        var dao = await dbContext.FindAsync<ArticleDao>(id);
        if(dao == null)
        {
            throw new NotFoundException(typeof(Article), id);
        }

        var article = mapper.Map<Article>(dao);
        return article;
    }

    private ArticleDao CreateDao(Article domain)
    {
        Guid id = Guid.NewGuid();
        Logs.Props().DiagnosticPush(LogKeys.Articles.Id, id);
        modelIdCache.Add(domain.Url.AbsoluteUri, id);
        var dao = mapper.Map<ArticleDao>(domain);
        return dao;
    }
}
