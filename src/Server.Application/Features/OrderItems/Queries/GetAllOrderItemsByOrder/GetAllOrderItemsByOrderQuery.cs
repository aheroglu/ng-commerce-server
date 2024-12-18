using MediatR;
using Server.Application.Common;

namespace Server.Application.Features.OrderItems.Queries.GetAllOrderItemsByOrder;

public sealed record GetAllOrderItemsByOrderQuery(
    string OrderId) : IRequest<Result<List<GetAllOrderItemsByOrderQueryResponse>>>;
