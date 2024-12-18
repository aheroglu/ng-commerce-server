using MediatR;
using Server.Application.Common;
using Server.Domain.Entities;
using Server.Domain.Repositories;

namespace Server.Application.Features.CartItems.Commands.IncreaseCartItemQuantity;

internal sealed class IncreaseCartItemQuantityCommandHandler(
    ICartItemQueryRepository cartItemQueryRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<IncreaseCartItemQuantityCommand, Result<string>>
{
    public async Task<Result<string>> Handle(IncreaseCartItemQuantityCommand request, CancellationToken cancellationToken)
    {
        CartItem cartItem = await cartItemQueryRepository
            .GetByAsync(p => p.Id == request.CartItemId, cancellationToken, p => p.Product);

        if (cartItem is null) return Result<string>
                .Failure("Cart item not found!");

        if (cartItem.Quantity <= cartItem.Product.Stock) cartItem.Quantity++;

        await unitOfWork
            .SaveChangesAsync(cancellationToken);

        return Result<string>
            .Success("Your cart updated successfully");
    }
}
