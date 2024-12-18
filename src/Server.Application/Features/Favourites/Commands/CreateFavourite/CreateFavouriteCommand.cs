using MediatR;
using Server.Application.Common;

namespace Server.Application.Features.Favourites.Commands.CreateFavourite;

public sealed record CreateFavouriteCommand(
    string AppUserId,
    string ProductId,
    decimal PriceWhenAdded) : IRequest<Result<CreateFavouriteCommandResponse>>;
