using Articlib.Users.Domain.Validators;

namespace Articlib.Users.Domain.Test.TestUtilities;

internal static class TestValues
{
    public static class ValidUser
    {
        public const string Email = "bob@email.com";
        public static readonly string Name = new('a', NameRules.LengthMin);
    }
}