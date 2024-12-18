using Server.Application.Dtos;

namespace Server.Application.Features.Reviews.Queries.GetReviewById;

public sealed record GetReviewByIdQueryResponse(
    string Id,
    string ProductId,
    ProductDto Product,
    string AppUserId,
    AppUserDto AppUser,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
