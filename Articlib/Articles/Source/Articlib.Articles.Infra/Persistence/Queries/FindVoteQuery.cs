using Articlib.Articles.Domain.Articles;
using Articlib.Articles.Domain.Users;
using Articlib.Articles.Domain.Votes.Models;
using Articlib.Articles.Domain.Votes.Queries;
using AutoMapper;
using LittleByte.Domain;
using Microsoft.EntityFrameworkCore;

namespace Articlib.Articles.Infra.Persistence.Queries;

internal sealed class FindVoteQuery : IFindVoteQuery
{
    private readonly ArticlesContext articlesContext;
    private readonly IMapper mapper;

    public FindVoteQuery(ArticlesContext articlesContext, IMapper mapper)
    {
        this.articlesContext = articlesContext;
        this.mapper = mapper;
    }

    public async Task<Vote?> FindAsync(Id<Article> articleId, Id<User> userId)
    {
        var entity = await articlesContext.Votes.AsNoTracking()
            .FirstOrDefaultAsync(v => v.ArticleId == articleId.Value && v.UserId == userId.Value);

        Vote? vote = null;
        if(entity is not null)
        {
            vote = mapper.Map<Vote>(entity);
        }

        return vote;
    }
}
