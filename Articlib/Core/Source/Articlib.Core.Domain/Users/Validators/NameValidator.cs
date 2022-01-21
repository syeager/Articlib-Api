using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using FluentValidation;
using FluentValidation.Validators;
using LittleByte.Core.Common;

namespace Articlib.Core.Domain.Users;

internal static class NameValidatorExtension
{
    [SuppressMessage("ReSharper", "UnusedMethodReturnValue.Global")]
    public static IRuleBuilderOptions<T, Name> IsName<T>(this IRuleBuilder<T, Name> @this) =>
        @this.SetValidator(new NameValidator<T>());
}

internal class NameValidator<T> : PropertyValidator<T, Name>
{
    public override string Name => nameof(NameValidator<X>);

    public override bool IsValid(ValidationContext<T> context, Name value) => NameRules.Regex.IsMatch(value.Value);
}

public static class NameRules
{
    public const int LengthMin = 3;
    public const int LengthMax = 15;
    private const string RegexPattern = @"^([A-z0-9\-_]){3,15}$";
    public static readonly Regex Regex = new(RegexPattern);
}
