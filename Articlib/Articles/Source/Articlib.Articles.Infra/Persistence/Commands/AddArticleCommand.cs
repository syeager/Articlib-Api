using Articlib.Articles.Domain.Articles;
using Articlib.Articles.Infra.Persistence.Daos;
using AutoMapper;
using LittleByte.Validation;

namespace Articlib.Articles.Infra.Persistence;

internal sealed class AddArticleCommand : IAddArticleCommand
{
    private readonly ArticlesContext dbContext;
    private readonly IMapper mapper;

    public AddArticleCommand(ArticlesContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }

    public void Add(Valid<Article> article)
    {
        var domain = article.GetModelOrThrow();
        var dao = mapper.Map<ArticleDao>(domain);
        dbContext.Add((object)dao);
    }
}
