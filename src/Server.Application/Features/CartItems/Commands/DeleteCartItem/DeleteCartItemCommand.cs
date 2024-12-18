using MediatR;
using Server.Application.Common;

namespace Server.Application.Features.CartItems.Commands.DeleteCartItem;

public sealed record DeleteCartItemCommand(
    string CartItemId) : IRequest<Result<string>>;
