using MediatR;
using Server.Application.Common;

namespace Server.Application.Features.CartItems.Queries.GetCartItemsByUser;

public sealed record GetCartItemsByUserQuery(
    string AppUserId) : IRequest<Result<List<GetCartItemsByUserQueryResponse>>>;
