using System.ComponentModel.DataAnnotations.Schema;
using Articlib.Core.Infra.Articles.Models;

namespace Articlib.Core.Infra.Tags.Models;

internal class ArticleTagDao
{
    public Guid ArticleId { get; init; }
    public string TagName { get; init; } = null!;
    public uint Score { get; init; }

    public ArticleDao? Article { get; set; }
    [ForeignKey(nameof(TagName))]
    public TagDao? Tag { get; set; }
}
