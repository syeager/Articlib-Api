using Articlib.Users.Domain.Models;
using AutoMapper;

namespace Articlib.Users.Infra.Persistence.Mappings;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<Email, string>().ConvertUsing(x => x.Value);
        CreateMap<string, Email>().ConvertUsing(x => new Email(x));

        CreateMap<Name, string>().ConvertUsing(x => x.Value);
        CreateMap<string, Name>().ConvertUsing(x => new Name(x));

        CreateMap<User, UserDao>().ForMember(u => u.UserName, o => o.MapFrom(source => source.Name));
        CreateMap<UserDao, User>().DisableCtorValidation().ConvertUsing<UserConverter>();
    }
}
