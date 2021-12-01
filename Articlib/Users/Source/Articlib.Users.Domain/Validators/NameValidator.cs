using System.Text.RegularExpressions;
using Articlib.Users.Domain.Models;
using FluentValidation;
using FluentValidation.Validators;
using LittleByte;

namespace Articlib.Users.Domain.Validators;

internal static class NameValidatorExtension
{
    // ReSharper disable once UnusedMethodReturnValue.Global
    public static IRuleBuilderOptions<T, Name> IsName<T>(this IRuleBuilder<T, Name> @this)
    {
        return @this.SetValidator(new NameValidator<T>());
    }
}

internal class NameValidator<T> : PropertyValidator<T, Name>
{
    public override string Name => nameof(NameValidator<X>);

    public override bool IsValid(ValidationContext<T> context, Name value)
    {
        return NameRules.Regex.IsMatch(value.Value);
    }
}

public static class NameRules
{
    public const int LengthMin = 3;
    public const int LengthMax = 15;
    public const string RegexPattern = @"^([A-z0-9\-_]){3,15}$";
    public static readonly Regex Regex = new(RegexPattern);
}