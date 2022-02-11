using Articlib.Core.Domain.Articles;
using Articlib.Core.Domain.Users;
using Articlib.Core.Infra.Articles.Models;
using Articlib.Core.Infra.Persistence;
using AutoMapper;

namespace Articlib.Core.Infra.Articles.Commands;

internal sealed class AddArticlePostCommand : IAddArticlePostCommand
{
    private readonly CoreDb coreDb;
    private readonly IMapper mapper;

    public AddArticlePostCommand(CoreDb coreDb, IMapper mapper)
    {
        this.coreDb = coreDb;
        this.mapper = mapper;
    }

    public void Add(ArticlePost post)
    {
        var entity = mapper.Map<ArticlePostDao>(post);
        coreDb.ArticlePosts.Add(entity);
    }
}
