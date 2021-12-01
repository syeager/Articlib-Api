using Articlib.Core.Domain.Articles;
using AutoMapper;
using LittleByte.Core.Exceptions;
using LittleByte.Infra;
using LittleByte.Validation;

namespace Articlib.Core.Infra.Articles;

public interface IArticleReadRepo : IRepo
{
    public Task<Article> GetByIdAsync(Guid id);
}

public interface IArticleWriteRepo : IArticleReadRepo, IArticleRepo
{
}

internal sealed class ArticleRepo : Repo<ArticlesContext>, IArticleWriteRepo
{
    public ArticleRepo(ArticlesContext dbContext, IMapper mapper)
        : base(dbContext, mapper)
    {
    }

    public Article Add(Valid<Article> article)
    {
        var domain = article.GetModelOrThrow();
        var dao = mapper.Map<ArticleDao>(domain);
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
}
