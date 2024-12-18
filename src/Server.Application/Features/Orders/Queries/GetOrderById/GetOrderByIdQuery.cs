using MediatR;
using Server.Application.Common;

namespace Server.Application.Features.Orders.Queries.GetOrderById;

public sealed record GetOrderByIdQuery(
    string OrderId) : IRequest<Result<GetOrderByIdQueryResponse>>;
