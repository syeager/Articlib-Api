using System.ComponentModel.DataAnnotations;

namespace Articlib.Core.Api.Users;

public class UserDto
{
    public Guid Id { get; init; }
    [Required]
    public string Name { get; init; } = null!;
}