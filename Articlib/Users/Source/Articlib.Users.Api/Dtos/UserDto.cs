using System.ComponentModel.DataAnnotations;

namespace Articlib.Users.Api.Dtos;

public record UserDto(Guid Id, [Required] string Name);