using FluentValidation;
using Server.Domain.Entities;

namespace Server.Application.Features.CartItems.Commands.CreateCartItem;

public sealed class CreateCartItemCommandValidator : AbstractValidator<CartItem>
{
    public CreateCartItemCommandValidator()
    {
        RuleFor(p => p.AppUserId).NotEmpty().NotNull();
        RuleFor(p => p.ProductId).NotEmpty().NotNull();
        RuleFor(p => p.Quantity).NotEmpty().NotNull().GreaterThanOrEqualTo((short)1);
    }
}
