using FluentValidation;

namespace Server.Application.Features.CartItems.Commands.IncreaseCartItemQuantity;

public sealed class IncreaseCartItemQuantityCommandValidator : AbstractValidator<IncreaseCartItemQuantityCommand>
{
    public IncreaseCartItemQuantityCommandValidator()
    {
        RuleFor(p => p.CartItemId).NotEmpty().NotNull();
    }
}
