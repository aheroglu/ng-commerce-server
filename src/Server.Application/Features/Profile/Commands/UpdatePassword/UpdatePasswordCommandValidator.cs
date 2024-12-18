using FluentValidation;

namespace Server.Application.Features.Profile.Commands.UpdatePassword;

public sealed class UpdatePasswordCommandValidator : AbstractValidator<UpdatePasswordCommand>
{
    public UpdatePasswordCommandValidator()
    {
        RuleFor(p => p.AppUserId).NotEmpty().NotNull();
        RuleFor(p => p.CurrentPassword).NotNull().NotEmpty().MinimumLength(6).MaximumLength(15); ;
        RuleFor(p => p.NewPassword).NotNull().NotEmpty().MinimumLength(6).MaximumLength(15);
        RuleFor(p => p.ConfirmPassword).NotNull().NotEmpty().MinimumLength(6).MaximumLength(15);
    }
}
