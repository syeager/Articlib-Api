using System.ComponentModel.DataAnnotations;
using LittleByte.Extensions.AspNet.Core;

namespace Articlib.Core.Api.Users;

public class UserDto : Dto
{
    [Required]
    public string Name { get; init; } = null!;
}