using Articlib.Core.Domain.Users;
using LittleByte.Domain;

namespace Articlib.Core.Domain.Test.Users;

internal static class Valid
{
    public static class User
    {
        public const string Email = "bob@email.com";
        public static readonly string Name = new('a', NameRules.LengthMin);

        public static Id<Domain.Users.User> Id() => Guid.NewGuid();
    }
}