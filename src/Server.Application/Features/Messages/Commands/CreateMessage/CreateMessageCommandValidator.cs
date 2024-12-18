using FluentValidation;

namespace Server.Application.Features.Messages.Commands.CreateMessage;

public sealed class CreateMessageCommandValidator : AbstractValidator<CreateMessageCommand>
{
    public CreateMessageCommandValidator()
    {
        RuleFor(p => p.Name).NotEmpty().NotNull().MinimumLength(4).MaximumLength(30);
        RuleFor(p => p.Email).NotEmpty().NotNull().EmailAddress();
        RuleFor(p => p.Topic).NotEmpty().NotNull();
        RuleFor(p => p.Content).NotEmpty().NotNull().MinimumLength(10).MaximumLength(500);
    }
}
