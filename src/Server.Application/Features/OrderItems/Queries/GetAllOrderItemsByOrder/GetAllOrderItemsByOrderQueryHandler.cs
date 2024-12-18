using MapsterMapper;
using MediatR;
using Server.Application.Common;
using Server.Domain.Repositories;

namespace Server.Application.Features.OrderItems.Queries.GetAllOrderItemsByOrder;

internal sealed class GetAllOrderItemsByOrderQueryHandler(
    IOrderItemQueryRepository orderItemQueryRepository,
    IMapper mapper) : IRequestHandler<GetAllOrderItemsByOrderQuery, Result<List<GetAllOrderItemsByOrderQueryResponse>>>
{
    public async Task<Result<List<GetAllOrderItemsByOrderQueryResponse>>> Handle(GetAllOrderItemsByOrderQuery request, CancellationToken cancellationToken)
    {
        var orderItems = mapper
            .Map<List<GetAllOrderItemsByOrderQueryResponse>>(await orderItemQueryRepository
            .GetOrderItemsByOrder(request.OrderId, cancellationToken));

        return Result<List<GetAllOrderItemsByOrderQueryResponse>>
            .Success(orderItems);
    }
}
