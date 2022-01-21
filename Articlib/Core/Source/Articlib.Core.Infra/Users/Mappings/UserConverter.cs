using System.Diagnostics.CodeAnalysis;
using Articlib.Core.Domain.Users;
using Articlib.Core.Infra.Users.Entities;
using AutoMapper;
using LittleByte.Validation;

namespace Articlib.Core.Infra.Users.Mappings;

[SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
internal sealed class UserConverter : ITypeConverter<UserDao, User>
{
    private readonly IModelValidator<User> validator;

    public UserConverter(IModelValidator<User> validator)
    {
        this.validator = validator;
    }

    public User Convert(UserDao source, User destination, ResolutionContext context)
    {
        var user = User.Create(
            validator,
            source.Id,
            new Email(source.Email),
            new Name(source.UserName));
        return user.GetModelOrThrow();
    }
}
