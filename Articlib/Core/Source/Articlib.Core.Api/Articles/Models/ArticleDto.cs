using System.ComponentModel.DataAnnotations;
using LittleByte.Extensions.AspNet.Core;

namespace Articlib.Core.Api.Articles;

public class ArticleDto : Dto
{
    [Required]
    [Url]
    public string Url { get; init; } = null!;

    [Required]
    public uint VoteCount { get; init; }

    [Required]
    public uint PostedCount { get; set; }

    [Required]
    public DateTime LastPostedDate { get; set; }
}
