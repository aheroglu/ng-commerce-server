using FluentValidation;

namespace Server.Application.Features.CartItems.Commands.DecreaseCartItemQuantity;

public sealed class DecreaseCartItemQuantityCommandValidator : AbstractValidator<DecreaseCartItemQuantityCommand>
{
    public DecreaseCartItemQuantityCommandValidator()
    {
        RuleFor(p => p.CartItemId).NotEmpty().NotNull();
    }
}
