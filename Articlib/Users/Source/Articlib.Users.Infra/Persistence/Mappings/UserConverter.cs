using System.Diagnostics.CodeAnalysis;
using Articlib.Users.Domain.Models;
using AutoMapper;
using LittleByte.Validation;

namespace Articlib.Users.Infra.Persistence.Mappings;

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
