namespace Articlib.Users.Domain.Models;

public record Name(string Value)
{
    public static implicit operator string(Name name) => name.Value;
}
