using FluentValidation;

namespace Server.Application.Features.CreditCards.Commands.DeleteCreditCard;

public sealed class DeleteCreditCardCommandValidator : AbstractValidator<DeleteCreditCardCommand>
{
    public DeleteCreditCardCommandValidator()
    {
        RuleFor(p => p.Id).NotEmpty().NotNull();
    }
}
