using FluentValidation;

namespace Server.Application.Features.CreditCards.Commands.CreateCreditCard;

public sealed class CreateCreditCardCommandValidator : AbstractValidator<CreateCreditCardCommand>
{
    public CreateCreditCardCommandValidator()
    {
        RuleFor(p => p.AppUserId).NotEmpty().NotNull();
        RuleFor(p => p.HolderName).NotEmpty().NotNull();
        RuleFor(p => p.Number).NotEmpty().NotNull();
        RuleFor(p => p.ExpirationMonth).NotEmpty().NotNull();
        RuleFor(p => p.ExpirationYear).NotEmpty().NotNull();
        RuleFor(p => p.CVV).NotEmpty().NotNull();
    }
}
