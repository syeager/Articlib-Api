using System.ComponentModel.DataAnnotations;

namespace Articlib.Core.Infra.Tags.Models;

internal class TagDao
{
    [Key]
    public string Name { get; set; } = null!;
}
