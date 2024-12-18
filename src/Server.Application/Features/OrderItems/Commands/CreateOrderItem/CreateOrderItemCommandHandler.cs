using MediatR;
using Server.Domain.Entities;
using Server.Domain.Repositories;

namespace Server.Application.Features.OrderItems.Commands.CreateOrderItem;

internal sealed class CreateOrderItemCommandHandler(
    IOrderItemCommandRepository orderItemCommandRepository,
    IProductQueryRepository productQueryRepository,
    IProductCommandRepository productCommandRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<CreateOrderItemCommand>
{
    public async Task Handle(CreateOrderItemCommand request, CancellationToken cancellationToken)
    {
        Product product = await productQueryRepository
            .GetByAsync(p => p.Id == request.ProductId, cancellationToken);

        if (product.Stock >= request.Quantity)
        {
            OrderItem orderItem = new()
            {
                OrderId = request.OrderId,
                ProductId = request.ProductId,
                Quantity = request.Quantity,
                TotalPrice = request.TotalPrice
            };

            product.Stock -= request.Quantity;

            productCommandRepository
                .Update(product);

            await orderItemCommandRepository
                .CreateAsync(orderItem, cancellationToken);

            await unitOfWork
                .SaveChangesAsync(cancellationToken);
        }
    }
}