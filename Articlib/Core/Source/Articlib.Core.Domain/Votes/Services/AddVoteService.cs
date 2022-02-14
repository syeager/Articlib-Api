using Articlib.Core.Domain.Articles;
using Articlib.Core.Domain.Users;
using Articlib.Core.Domain.Votes.Commands;
using Articlib.Core.Domain.Votes.Models;
using Articlib.Core.Domain.Votes.Queries;

namespace Articlib.Core.Domain.Votes.Services;

public interface IAddVoteService
{
    Task<Article> AddAsync(Article article, User user);
}

public sealed class AddVoteService : IAddVoteService
{
    private readonly ILogger logger = Log.ForContext<AddVoteService>();
    private readonly IDateService dateService;
    private readonly IFindVoteQuery findVoteQuery;
    private readonly IAddVoteCommand addVoteCommand;

    public AddVoteService(IDateService dateService, IFindVoteQuery findVoteQuery, IAddVoteCommand addVoteCommand)
    {
        this.dateService = dateService;
        this.findVoteQuery = findVoteQuery;
        this.addVoteCommand = addVoteCommand;
    }

    public async Task<Article> AddAsync(Article article, User user)
    {
        var vote = await findVoteQuery.FindAsync(article.Id, user.Id);
        if(vote is not null)
        {
            logger.Information("Vote already exists");
            return article;
        }

        article.AddVote();

        vote = new Vote(article.Id, user.Id, dateService.UtcNow);
        addVoteCommand.Add(vote);
        logger.Information("Created vote");

        return article;
    }
}
