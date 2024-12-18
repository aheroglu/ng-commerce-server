using MediatR;
using Server.Application.Common;
using Server.Domain.Entities;
using Server.Domain.Repositories;

namespace Server.Application.Features.CartItems.Commands.DeleteCartItem;

internal sealed class DeleteCartItem(
    ICartItemQueryRepository cartItemQueryRepository,
    ICartItemCommandRepository cartItemCommandRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteCartItemCommand, Result<string>>
{
    public async Task<Result<string>> Handle(DeleteCartItemCommand request, CancellationToken cancellationToken)
    {
        CartItem cartItem = await cartItemQueryRepository
            .GetByAsync(p => p.Id == request.CartItemId, cancellationToken);

        if (cartItem is null) return Result<string>
                .Failure("Cart item not found!");

        cartItemCommandRepository
            .Delete(cartItem);

        await unitOfWork
            .SaveChangesAsync(cancellationToken);

        return Result<string>
            .Success("Product removed from you cart");
    }
}
