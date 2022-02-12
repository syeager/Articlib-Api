using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Articlib.Core.Api.Articles;

[SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Global")]
[SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
public class PostArticleRequest
{
    [Required]
    [Url]
    public string Url { get; init; } = null!;

    [Required]
    public Guid PosterId { get; init; }

    [Required]
    [Range(1, 5)]
    public List<string> Tags { get; set; } = null!;
}
