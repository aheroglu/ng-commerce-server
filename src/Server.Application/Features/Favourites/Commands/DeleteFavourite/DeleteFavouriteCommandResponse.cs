namespace Server.Application.Features.Favourites.Commands.DeleteFavourite;

public sealed record DeleteFavouriteCommandResponse(
    string Id,
    string AppUserId,
    string ProductId,
    decimal PriceWhenAdded,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
