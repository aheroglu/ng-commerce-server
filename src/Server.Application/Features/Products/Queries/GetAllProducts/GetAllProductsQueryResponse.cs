using Server.Application.Dtos;

namespace Server.Application.Features.Products.Queries.GetAllProducts;

public sealed record GetAllProductsQueryResponse(
    string Id,
    string Name,
    string CategoryId,
    CategoryDto Category,
    string BrandId,
    BrandDto Brand,
    string Model,
    string Description,
    string Url,
    decimal Price,
    int Stock,
    List<ProductImageDto> ProductImages,
    DateTime CreatedAt,
    DateTime? UpdatedAt);