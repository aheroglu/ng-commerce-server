using Server.Application.Dtos;

namespace Server.Application.Features.Reviews.Queries.GetAllReviews;

public sealed record GetAllReviewsQueryResponse(
    string Id,
    string ProductId,
    ProductDto Product,
    string AppUserId,
    AppUserDto AppUser,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
