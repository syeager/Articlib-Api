using Articlib.Core.Infra.Users.Entities;

namespace Articlib.Core.Infra.Test;

internal static class TV
{
    public static class Users
    {
        public static UserDao NewUser()
        {
            var entity = new UserDao
            {
                Id = Guid.NewGuid(),
                Email = "x@x.x",
                UserName = "alice",
            };
            return entity;
        }

        public static UserDao[] NewUsers(int count)
        {
            var entities = new UserDao[count];
            for(var i = 0; i < count; i++)
            {
                entities[i] = NewUser();
            }

            return entities;
        }
    }
}
