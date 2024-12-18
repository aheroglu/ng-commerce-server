using MediatR;
using Server.Application.Common;
using Server.Domain.Entities;
using Server.Domain.Repositories;

namespace Server.Application.Features.CartItems.Commands.DecreaseCartItemQuantity;

internal sealed class DecreaseCartItemQuantityCommandHandler(
    ICartItemQueryRepository cartItemQueryRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DecreaseCartItemQuantityCommand, Result<string>>
{
    public async Task<Result<string>> Handle(DecreaseCartItemQuantityCommand request, CancellationToken cancellationToken)
    {
        CartItem cartItem = await cartItemQueryRepository
            .GetByAsync(p => p.Id == request.CartItemId, cancellationToken, p => p.Product);

        if (cartItem is null) return Result<string>
                .Failure("Cart item not found!");

        if (cartItem.Quantity > 1) cartItem.Quantity--;

        await unitOfWork
            .SaveChangesAsync(cancellationToken);

        return Result<string>
            .Success("Your cart updated successfully");
    }
}
