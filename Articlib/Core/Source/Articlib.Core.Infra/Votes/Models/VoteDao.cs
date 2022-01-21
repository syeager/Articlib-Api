namespace Articlib.Core.Infra.Votes.Models;

internal sealed class VoteDao
{
    public Guid ArticleId { get; init; }
    public Guid UserId { get; init; }
    public DateTime Date { get; init; }
}
