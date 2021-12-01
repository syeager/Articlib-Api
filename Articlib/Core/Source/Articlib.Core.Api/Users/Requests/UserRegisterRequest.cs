using System.ComponentModel.DataAnnotations;
using Articlib.Core.Domain.Users;

namespace Articlib.Core.Api.Users;

public record UserRegisterRequest(
    [Required] [EmailAddress] string Email,
    [Required] [StringLength(NameRules.LengthMax, MinimumLength = NameRules.LengthMin)]
    string Name
);