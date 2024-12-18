using MapsterMapper;
using MediatR;
using Server.Application.Common;
using Server.Domain.Repositories;

namespace Server.Application.Features.Orders.Queries.GetOrderById;

internal sealed class GetOrderByIdQueryHandler(
    IOrderQueryRepository orderQueryRepository,
    IMapper mapper) : IRequestHandler<GetOrderByIdQuery, Result<GetOrderByIdQueryResponse>>
{
    public async Task<Result<GetOrderByIdQueryResponse>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var order = mapper
            .Map<GetOrderByIdQueryResponse>(await orderQueryRepository
            .GetByAsync(
                p => p.OrderId == request.OrderId,
                cancellationToken,
                p => p.AppUser,
                p => p.Address,
                p => p.CreditCard));

        if (order is null) return Result<GetOrderByIdQueryResponse>
                .Failure("Order not found!");

        return Result<GetOrderByIdQueryResponse>
            .Success(order);
    }
}
