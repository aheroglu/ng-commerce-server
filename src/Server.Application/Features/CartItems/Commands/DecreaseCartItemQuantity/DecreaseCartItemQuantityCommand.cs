using MediatR;
using Server.Application.Common;

namespace Server.Application.Features.CartItems.Commands.DecreaseCartItemQuantity;

public sealed record DecreaseCartItemQuantityCommand(
    string CartItemId) : IRequest<Result<string>>;
