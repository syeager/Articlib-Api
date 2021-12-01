using AutoMapper;

namespace Articlib.Core.Api.Users;

public static class UserMappingConfiguration
{
    public static IMapperConfigurationExpression AddUsers(this IMapperConfigurationExpression @this)
    {
        @this.AddProfile<UserProfile>();
        @this.AddProfile<Infra.Users.UserProfile>();
        return @this;
    }
}