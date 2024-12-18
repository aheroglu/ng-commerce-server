﻿using Server.Application.Dtos;

namespace Server.Application.Features.Favourites.Queries.GetAllFavouritesByUser;

public sealed record GetAllFavouritesByUserQueryResponse(
    string Id,
    string AppUserId,
    AppUserDto AppUser,
    string ProductId,
    ProductDto Product,
    decimal PriceWhenAdded,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
