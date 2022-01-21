using Articlib.Articles.Domain.Articles;
using Articlib.Articles.Domain.Users;
using Articlib.Articles.Domain.Votes.Commands;
using Articlib.Articles.Domain.Votes.Models;
using Articlib.Articles.Domain.Votes.Queries;
using LittleByte.Core.Dates;
using Serilog;

namespace Articlib.Articles.Domain.Votes.Services;

public interface IAddVote
{
    Task<Article> AddAsync(Article article, User user);
}

public sealed class AddVote : IAddVote
{
    private readonly ILogger logger = Log.ForContext<AddVote>();
    private readonly IDateService dateService;
    private readonly IFindVoteQuery findVoteQuery;
    private readonly IAddVoteCommand addVoteCommand;

    public AddVote(IDateService dateService, IFindVoteQuery findVoteQuery, IAddVoteCommand addVoteCommand)
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
