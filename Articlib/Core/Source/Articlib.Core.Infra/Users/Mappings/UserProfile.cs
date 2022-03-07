using Articlib.Core.Domain.Users;
using Articlib.Core.Infra.Users.Entities;
using AutoMapper;
using LittleByte.Validation;

namespace Articlib.Core.Infra.Users.Mappings;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<Email, string>().ConvertUsing(x => x.Value);
        CreateMap<string, Email>().ConvertUsing(x => new Email(x));

        CreateMap<Name, string>().ConvertUsing(x => x.Value);
        CreateMap<string, Name>().ConvertUsing(x => new Name(x));

        CreateMap<Valid<User>, UserDao>().ForMember(u => u.UserName, o => o.MapFrom(source => source.GetModelOrThrow().Name));
        CreateMap<UserDao, Valid<User>>().DisableCtorValidation().ConvertUsing<UserConverter>();
    }
}
