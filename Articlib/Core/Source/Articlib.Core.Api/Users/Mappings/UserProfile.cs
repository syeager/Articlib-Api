using Articlib.Core.Domain.Users;
using AutoMapper;

namespace Articlib.Core.Api.Users;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDto>();
    }
}