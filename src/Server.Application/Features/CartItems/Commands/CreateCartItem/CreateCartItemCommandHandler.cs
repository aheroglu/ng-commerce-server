using MapsterMapper;
using MediatR;
using Server.Application.Common;
using Server.Domain.Entities;
using Server.Domain.Repositories;

namespace Server.Application.Features.CartItems.Commands.CreateCartItem;

internal sealed class CreateCartItemCommandHandler(
    ICartItemCommandRepository cartItemCommandRepository,
    ICartItemQueryRepository cartItemQueryRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<CreateCartItemCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateCartItemCommand request, CancellationToken cancellationToken)
    {
        bool isCartItemExists = await cartItemQueryRepository
            .IsCartItemExists(request.AppUserId, request.ProductId, cancellationToken);

        if (isCartItemExists)
        {
            CartItem item = await cartItemQueryRepository
                .GetByAsync(p => p.AppUserId == request.AppUserId && p.ProductId == request.ProductId, cancellationToken);

            if (item is null) return Result<string>
                    .Failure("Cart item not found!");

            item.Quantity++;

            await unitOfWork
                .SaveChangesAsync(cancellationToken);
        }

        else
        {
            CartItem cartItem = mapper.Map<CartItem>(request);

            await cartItemCommandRepository
                .CreateAsync(cartItem, cancellationToken);

            await unitOfWork
                .SaveChangesAsync(cancellationToken);
        }

        return Result<string>
            .Success("Product added to your cart");
    }
}
