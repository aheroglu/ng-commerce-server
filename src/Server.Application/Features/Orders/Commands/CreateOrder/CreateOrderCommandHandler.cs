using MapsterMapper;
using MediatR;
using Server.Application.Common;
using Server.Domain.Entities;
using Server.Domain.Repositories;

namespace Server.Application.Features.Orders.Commands.CreateOrder;

internal sealed class CreateOrderCommandHandler(
    ICommandRepository<Order> commandRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<CreateOrderCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        Order order = mapper.Map<Order>(request);

        await commandRepository
            .CreateAsync(order, cancellationToken);

        await unitOfWork
            .SaveChangesAsync(cancellationToken);

        return Result<string>
            .Success(order.Id);
    }
}
