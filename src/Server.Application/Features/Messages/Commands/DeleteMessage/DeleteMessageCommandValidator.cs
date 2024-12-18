using FluentValidation;

namespace Server.Application.Features.Messages.Commands.DeleteMessage;

public sealed class DeleteMessageCommandValidator : AbstractValidator<DeleteMessageCommand>
{
    public DeleteMessageCommandValidator()
    {
        RuleFor(p => p.Id).NotEmpty().NotNull();
    }
}
