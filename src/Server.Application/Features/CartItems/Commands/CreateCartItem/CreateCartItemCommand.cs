using MediatR;
using Server.Application.Common;

namespace Server.Application.Features.CartItems.Commands.CreateCartItem;

public sealed record CreateCartItemCommand(
    string AppUserId,
    string ProductId,
    short Quantity) : IRequest<Result<string>>;