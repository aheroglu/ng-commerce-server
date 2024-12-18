using FluentValidation;

namespace Server.Application.Features.Auth.Commands.SignUp;

public sealed class SignUpCommandValidator : AbstractValidator<SignUpCommand>
{
    public SignUpCommandValidator()
    {
        RuleFor(p => p.FullName).NotEmpty().NotNull().MinimumLength(4).MaximumLength(30);
        RuleFor(p => p.Email).NotNull().NotEmpty().EmailAddress();
        RuleFor(p => p.Password).NotNull().NotEmpty();
    }
}
