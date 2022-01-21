using System.ComponentModel.DataAnnotations;

namespace Articlib.Core.Api.Users;

public sealed record LogInRequest(
    [Required] [EmailAddress] string Email,
    [Required] string Password);
