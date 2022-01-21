using System.ComponentModel.DataAnnotations;

namespace Articlib.Articles.Api.Requests;

public sealed record VoteRequest(
    [Required] Guid ArticleId,
    [Required] Guid UserId);
