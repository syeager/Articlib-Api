using Articlib.Core.Domain.Articles;
using Articlib.Core.Domain.Tags.Queries;
using Articlib.Core.Infra.Persistence;
using AutoMapper;
using LittleByte.Domain;
using LittleByte.Extensions.AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Articlib.Core.Infra.Tags.Services;

internal sealed class LoadArticleTagsQuery : ILoadArticleTagsQuery
{
    private readonly CoreDb coreDb;
    private readonly IMapper mapper;

    public LoadArticleTagsQuery(CoreDb coreDb, IMapper mapper)
    {
        this.coreDb = coreDb;
        this.mapper = mapper;
    }

    public async Task<IReadOnlyCollection<ArticleTag>> LoadAsync(Id<Article> articleId)
    {
        var entities = await coreDb.ArticleTags
            .Where(at => at.ArticleId == articleId.Value)
            .ToArrayAsync();

        var articleTags = mapper.MapRange<ArticleTag>(entities);
        return articleTags;
    }
}
