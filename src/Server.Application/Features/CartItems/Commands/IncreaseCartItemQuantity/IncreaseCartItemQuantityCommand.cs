using MediatR;
using Server.Application.Common;

namespace Server.Application.Features.CartItems.Commands.IncreaseCartItemQuantity;

public sealed record IncreaseCartItemQuantityCommand(
    string CartItemId) : IRequest<Result<string>>;
