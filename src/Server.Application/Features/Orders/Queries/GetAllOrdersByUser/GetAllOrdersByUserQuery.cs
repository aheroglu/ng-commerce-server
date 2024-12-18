using MediatR;
using Server.Application.Common;

namespace Server.Application.Features.Orders.Queries.GetAllOrdersByUser;

public sealed record GetAllOrdersByUserQuery(
    string AppUserId) : IRequest<Result<List<GetAllOrdersByUserQueryResponse>>>;
