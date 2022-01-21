using System.Text.RegularExpressions;
using FluentValidation;
using FluentValidation.Validators;

namespace Articlib.Users.Domain.Validators;

internal static class EmailValidatorExtension
{
    // ReSharper disable once UnusedMethodReturnValue.Global
    public static IRuleBuilderOptions<T, Email> IsEmailAddress<T>(this IRuleBuilder<T, Email> @this) =>
        @this.SetValidator(new EmailValidator<T>());
}

internal static class EmailValidator
{
    public static readonly Regex Regex = new(@"^\w+@{1}\w+\.{1}\w+$");
}

internal class EmailValidator<T> : PropertyValidator<T, Email>
{
    public override string Name => nameof(EmailValidator);

    public override bool IsValid(ValidationContext<T> context, Email value) =>
        EmailValidator.Regex.IsMatch(value.Value);
}
