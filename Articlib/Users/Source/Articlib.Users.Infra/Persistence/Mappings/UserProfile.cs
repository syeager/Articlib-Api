using Articlib.Users.Domain.Models;
using Articlib.Users.Infra.Persistence.Entities;
using AutoMapper;
using LittleByte.Infra;

namespace Articlib.Users.Infra;

public class UserProfile : Profile
{
    public UserProfile(IEntityIdReadCache modelCache)
    {
        CreateMap<Email, string>().ConvertUsing(x => x.Value);
        CreateMap<string, Email>().ConvertUsing(x => new Email(x));

        CreateMap<Name, string>().ConvertUsing(x => x.Value);
        CreateMap<string, Name>().ConvertUsing(x => new Name(x));

        CreateMap<User, UserDao>()
            .ForMember(a => a.Id, m => m.MapFrom((domain, _) => modelCache.Get(domain.Email.Value)));
    }
}
