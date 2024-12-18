using FluentValidation;

namespace Server.Application.Features.Blacklists.Commands.UpdateBlacklist;

public sealed class UpdateBlacklistCommandValidator : AbstractValidator<UpdateBlacklistCommand>
{
    public UpdateBlacklistCommandValidator()
    {
        RuleFor(p => p.Id).NotEmpty().NotNull();
        RuleFor(p => p.Reason).NotEmpty().NotNull().MaximumLength(500);
    }
}
