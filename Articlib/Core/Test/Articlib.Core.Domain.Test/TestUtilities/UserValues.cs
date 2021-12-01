using Articlib.Core.Domain.Users;
using LittleByte.Domain;

namespace Articlib.Core.Domain.Test;

internal static partial class TV
{
    public static class Users
    {
        public const string Email = "bob@email.com";
        public static readonly string Name = new('a', NameRules.LengthMin);

        public static Id<User> Id() => Guid.NewGuid();
    }
}