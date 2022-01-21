using Articlib.Users.Domain.Models;
using Articlib.Users.Domain.Validators;
using LittleByte.Domain;

namespace Articlib.Users.Domain.Test.TestUtilities;

internal static class TV
{
    public static class Users
    {
        public static readonly Email Email = new("bob@email.com");
        public static readonly Name Name = new(new string('a', NameRules.LengthMin));
        public static readonly Password Password = new("abc123");

        public static Id<User> Id() => Guid.NewGuid();
    }
}
