using Articlib.Articles.Domain.Users;
using LittleByte.Domain;

namespace Articlib.Articles.Domain.Test;

internal static partial class TV
{
    public static class Users
    {
        public static Id<User> Id() => Guid.NewGuid();
    }
}
