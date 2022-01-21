using Articlib.Articles.Domain.Votes.Commands;
using Articlib.Articles.Domain.Votes.Models;
using Articlib.Articles.Infra.Persistence.Daos;
using AutoMapper;

namespace Articlib.Articles.Infra.Persistence.Commands.Votes;

internal sealed class AddVoteCommand : IAddVoteCommand
{
    private readonly ArticlesContext articlesContext;
    private readonly IMapper mapper;
    
    public AddVoteCommand(ArticlesContext articlesContext, IMapper mapper)
    {
        this.articlesContext = articlesContext;
        this.mapper = mapper;
    }

    public void Add(Vote vote)
    {
        var entity = mapper.Map<VoteDao>(vote);
        articlesContext.Add(entity);
    }
}
