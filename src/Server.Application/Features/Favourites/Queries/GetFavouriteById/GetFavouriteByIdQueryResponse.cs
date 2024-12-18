using Server.Application.Dtos;

namespace Server.Application.Features.Favourites.Queries.GetFavouriteById;

public sealed record GetFavouriteByIdQueryResponse(
    string Id,
    string AppUserId,
    AppUserDto AppUser,
    string ProductId,
    ProductDto Product,
    decimal PriceWhenAdded,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
