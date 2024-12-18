using FluentValidation;

namespace Server.Application.Features.CartItems.Commands.DeleteCartItem;

public sealed class DeleteCartItemCommandValidator : AbstractValidator<DeleteCartItemCommand>
{
    public DeleteCartItemCommandValidator()
    {
        RuleFor(p => p.CartItemId).NotEmpty().NotNull();
    }
}
