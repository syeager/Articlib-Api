using System.ComponentModel.DataAnnotations;

namespace Articlib.Core.Api.Votes.Requests;

public sealed record VoteRequest(
    [Required] Guid ArticleId,
    [Required] Guid UserId);
