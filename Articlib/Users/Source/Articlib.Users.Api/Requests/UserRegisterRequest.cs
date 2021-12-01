using System.ComponentModel.DataAnnotations;
using Articlib.Users.Domain.Validators;

namespace Articlib.Users.Api.Requests;

public record UserRegisterRequest(
    [Required] [EmailAddress] string Email,
    [Required] [StringLength(NameRules.LengthMax, MinimumLength = NameRules.LengthMin)]
    string Name
);