using MapsterMapper;
using MediatR;
using Server.Application.Common;
using Server.Domain.Repositories;

namespace Server.Application.Features.Orders.Queries.GetAllOrdersByUser;

internal sealed class GetAllOrdersByUserQueryHandler(
    IOrderQueryRepository orderQueryRepository,
    IMapper mapper) : IRequestHandler<GetAllOrdersByUserQuery, Result<List<GetAllOrdersByUserQueryResponse>>>
{
    public async Task<Result<List<GetAllOrdersByUserQueryResponse>>> Handle(GetAllOrdersByUserQuery request, CancellationToken cancellationToken)
    {
        var orders = mapper
            .Map<List<GetAllOrdersByUserQueryResponse>>(await orderQueryRepository
            .GetOrdersByUser(request.AppUserId, cancellationToken));

        return Result<List<GetAllOrdersByUserQueryResponse>>
            .Success(orders);
    }
}
