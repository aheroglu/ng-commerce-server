using FluentValidation;

namespace Server.Application.Features.Blacklists.Commands.CreateBlacklist;

public sealed class CreateBlacklistCommandValidator : AbstractValidator<CreateBlacklistCommand>
{
    public CreateBlacklistCommandValidator()
    {
        RuleFor(p => p.AppUserId).NotEmpty().NotNull();
        RuleFor(p => p.Reason).NotEmpty().NotNull().MaximumLength(500);
    }
}
