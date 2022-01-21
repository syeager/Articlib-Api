using System.ComponentModel.DataAnnotations;
using LittleByte.Extensions.AspNet.Core;

namespace Articlib.Users.Api.Dtos;

public class UserDto : Dto
{
    [Required]
    public string Name { get; init; } = null!;
}
