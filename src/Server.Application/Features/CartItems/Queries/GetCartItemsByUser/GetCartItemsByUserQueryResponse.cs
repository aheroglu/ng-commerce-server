using Server.Application.Dtos;

namespace Server.Application.Features.CartItems.Queries.GetCartItemsByUser;

public sealed record GetCartItemsByUserQueryResponse(
    string Id,
    string AppUserId,
    AppUserDto AppUser,
    string ProductId,
    ProductDto Product,
    short Quantity);
