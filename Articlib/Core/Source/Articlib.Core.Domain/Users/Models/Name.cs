namespace Articlib.Core.Domain.Users;

public record Name(string Value)
{
    public static implicit operator string(Name name) => name.Value;
}
