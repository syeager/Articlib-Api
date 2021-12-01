using LittleByte.Infra.Models;

namespace Articlib.Users.Infra.Persistence.Entities;

internal class UserDao : Entity
{
    public string Email {get; init; } = null!;
    public string Name { get; init; } = null!;

    public override string Identifier => Email;
}