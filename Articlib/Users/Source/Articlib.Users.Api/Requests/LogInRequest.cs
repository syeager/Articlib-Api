using System.ComponentModel.DataAnnotations;

namespace Articlib.Users.Api.Requests;

public sealed record LogInRequest(
    [Required] [EmailAddress] string Email,
    [Required] string Password);