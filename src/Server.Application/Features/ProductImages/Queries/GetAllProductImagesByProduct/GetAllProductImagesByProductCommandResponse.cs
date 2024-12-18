using Server.Application.Dtos;

namespace Server.Application.Features.ProductImages.Queries.GetProductImagesByProduct;

public sealed record GetAllProductImagesByProductCommandResponse(
    string Id,
    string Image,
    ProductDto Product,
    DateTime CreatedAt,
    DateTime? UpdatedAt);