using MediatR;
using Server.Application.Common;

namespace Server.Application.Features.CartItems.Commands.ClearCartByUser;

public sealed record ClearCartByUserCommand(
    string AppUserId) : IRequest<Result<string>>;
