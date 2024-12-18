using MediatR;
using Server.Application.Common;
using Server.Domain.Repositories;

namespace Server.Application.Features.CartItems.Commands.ClearCartByUser;

internal sealed class ClearCartByUserCommandHandler(
    ICartItemQueryRepository cartItemQueryRepository,
    ICartItemCommandRepository cartItemCommandRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<ClearCartByUserCommand, Result<string>>
{
    public async Task<Result<string>> Handle(ClearCartByUserCommand request, CancellationToken cancellationToken)
    {
        var cartItems = await cartItemQueryRepository
            .GetAllByUser(request.AppUserId, cancellationToken);

        foreach (var cartItem in cartItems)
        {
            cartItemCommandRepository
                .Delete(cartItem);
        }

        await unitOfWork
            .SaveChangesAsync(cancellationToken);

        return Result<string>
            .Success("Your cart has been cleared");
    }
}
