using Articlib.Core.Domain.Articles;
using Articlib.Core.Domain.Articles.Queries;
using Articlib.Core.Infra.Persistence;
using AutoMapper;
using LittleByte.Validation;
using Microsoft.EntityFrameworkCore;

namespace Articlib.Core.Infra.Articles.Queries;

internal sealed class FindArticleByUrlQuery : IFindArticleByUrlQuery
{
    private readonly CoreDb coreDb;
    private readonly IMapper mapper;

    public FindArticleByUrlQuery(CoreDb coreDb, IMapper mapper)
    {
        this.coreDb = coreDb;
        this.mapper = mapper;
    }

    public async Task<Valid<Article>?> FindAsync(Uri url)
    {
        var urlString = url.AbsoluteUri; // TODO: Normalize.
        var articleEntity = await coreDb.Articles.FirstOrDefaultAsync(a => a.Url == urlString);
        if(articleEntity is null)
        {
            return null;
        }

        var article = mapper.Map<Valid<Article>>(articleEntity);
        return article;
    }
}
