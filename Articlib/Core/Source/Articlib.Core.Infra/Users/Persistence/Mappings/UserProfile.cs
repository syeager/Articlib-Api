using Articlib.Core.Domain.Users;
using AutoMapper;

namespace Articlib.Core.Infra.Users;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<Email, string>().ConvertUsing(x => x.Value);
        CreateMap<string, Email>().ConvertUsing(x => new Email(x));

        CreateMap<Name, string>().ConvertUsing(x => x.Value);
        CreateMap<string, Name>().ConvertUsing(x => new Name(x));

        CreateMap<User, UserDao>();
    }
}
