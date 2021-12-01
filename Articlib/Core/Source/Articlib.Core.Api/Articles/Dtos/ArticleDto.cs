using LittleByte.Extensions.AspNet.Core;
using Microsoft.Build.Framework;

namespace Articlib.Core.Api.Articles;

public class ArticleDto : Dto
{
    [Required]
    public Uri Url { get; init; } = null!;
    [Required]
    public Guid PosterId { get; init; }
}
