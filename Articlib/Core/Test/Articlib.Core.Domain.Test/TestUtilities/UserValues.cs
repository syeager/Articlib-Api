using Articlib.Core.Domain.Users;
using LittleByte.Domain;
using LittleByte.Validation;

namespace Articlib.Core.Domain.Test;

internal static partial class TV
{
    public static class Users
    {
        public static readonly Email Email = new("bob@email.com");
        public static readonly Name Name = new(new string('a', NameRules.LengthMin));
        public static readonly Password Password = new("abc123");

        public static Id<User> Id() => Guid.NewGuid();
        public static Valid<User> New() => User.Create(new SuccessModelValidator<User>(), Id(), Email, Name);
    }
}
