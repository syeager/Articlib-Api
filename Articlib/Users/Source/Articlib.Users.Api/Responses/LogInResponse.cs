using System.Diagnostics.CodeAnalysis;
using Articlib.Users.Api.Dtos;

namespace Articlib.Users.Api.Responses;

public sealed class LogInResponse
{
    public bool Succeeded { get; init; }

    [MemberNotNullWhen(true, nameof(Succeeded))]
    public string? AccessToken { get; init; }

    [MemberNotNullWhen(true, nameof(Succeeded))]
    public UserDto? User { get; init; }

    [MemberNotNullWhen(false, nameof(Succeeded))]
    public List<string>? Errors { get; init; }
}
