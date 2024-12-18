using Server.Application.Dtos;

namespace Server.Application.Features.ProductImages.Queries.GetProductImageById;

public sealed record GetProductImageByIdQueryResponse(
    string Id,
    string Image,
    ProductDto Product,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
