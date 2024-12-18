using FluentValidation;

namespace Server.Application.Features.Blacklists.Commands.DeleteBlacklist;

public sealed class DeleteBlacklistCommandValidator : AbstractValidator<DeleteBlacklistCommand>
{
    public DeleteBlacklistCommandValidator()
    {
        RuleFor(p => p.Id).NotNull().NotEmpty();
    }
}
