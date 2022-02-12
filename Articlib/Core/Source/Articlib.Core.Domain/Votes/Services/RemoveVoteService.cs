using Articlib.Core.Domain.Articles;
using Articlib.Core.Domain.Users;
using Articlib.Core.Domain.Votes.Commands;
using Articlib.Core.Domain.Votes.Queries;
using Serilog;

namespace Articlib.Core.Domain.Votes.Services;

public interface IRemoveVoteService
{
    Task<Article> RemoveAsync(Article article, User user);
}

public sealed class RemoveVoteService : IRemoveVoteService
{
    private readonly ILogger logger = Log.ForContext<RemoveVoteService>();
    private readonly IFindVoteQuery findVoteQuery;
    private readonly IRemoveVoteCommand removeVoteCommand;

    public RemoveVoteService(IFindVoteQuery findVoteQuery, IRemoveVoteCommand removeVoteCommand)
    {
        this.findVoteQuery = findVoteQuery;
        this.removeVoteCommand = removeVoteCommand;
    }

    public async Task<Article> RemoveAsync(Article article, User user)
    {
        var vote = await findVoteQuery.FindAsync(article.Id, user.Id);

        if(vote is null)
        {
            logger.Information("Vote doesn't exists");
            return article;
        }

        article.RemoveVote();

        removeVoteCommand.Remove(vote);
        logger.Information("Removed vote");

        return article;
    }
}
