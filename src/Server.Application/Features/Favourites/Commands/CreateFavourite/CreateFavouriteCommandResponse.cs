namespace Server.Application.Features.Favourites.Commands.CreateFavourite;

public sealed record CreateFavouriteCommandResponse(
    string Id,
    string AppUserId,
    string ProductId,
    decimal PriceWhenAdded,
    DateTime CreatedAt);
