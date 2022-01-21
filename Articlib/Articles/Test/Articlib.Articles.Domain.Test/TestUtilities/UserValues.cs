using LittleByte.Domain;

namespace Articlib.Core.Domain.Test;

internal static partial class TV
{
    public static class Users
    {
        public static Id<User> Id() => Guid.NewGuid();
    }
}
