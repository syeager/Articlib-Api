using System.IdentityModel.Tokens.Jwt;
using Articlib.Users.Api.Dtos;
using Articlib.Users.Api.Responses;
using Articlib.Users.Domain.Models;
using Articlib.Users.Domain.Results;
using AutoMapper;

namespace Articlib.Users.Api.Mappings;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<JwtSecurityToken, string>().ConvertUsing<JwtSecurityTokenConverter>();
        CreateMap<User, UserDto>();
        CreateMap<LogInResult, LogInResponse>();
    }
}
