using FluentValidation;

namespace Server.Application.Features.Profile.Commands.UpdateProfile;

public sealed class UpdateProfileCommandValidator : AbstractValidator<UpdateProfileCommand>
{
    public UpdateProfileCommandValidator()
    {
        RuleFor(p => p.Id).NotNull().NotEmpty();
        RuleFor(p => p.FullName).NotEmpty().NotNull().MinimumLength(4).MaximumLength(30);
        RuleFor(p => p.Email).NotNull().NotEmpty().EmailAddress();
        RuleFor(p => p.BirthDate).NotNull().NotEmpty().LessThan(DateTime.Now);
    }
}
