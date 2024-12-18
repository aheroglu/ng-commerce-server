namespace Server.Application.Dtos;

public sealed record ProductDto(
    string Id,
    string Name,
    string CategoryId,
    CategoryDto CategoryDto,
    string BrandId,
    BrandDto BrandDto,
    string Model,
    string Description,
    string Url,
    decimal Price,
    int Stock,
    List<ProductImageDto> ProductImages,
    DateTime CreatedAt,
    DateTime? UpdatedAt);