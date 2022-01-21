using System.IdentityModel.Tokens.Jwt;
using Articlib.Core.Api.Users.Responses;
using Articlib.Core.Domain.Users;
using Articlib.Core.Domain.Users.Results;
using AutoMapper;

namespace Articlib.Core.Api.Users;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<JwtSecurityToken, string>().ConvertUsing<JwtSecurityTokenConverter>();
        CreateMap<User, UserDto>();
        CreateMap<LogInResult, LogInResponse>();
    }
}
