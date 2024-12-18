namespace Server.Application.Features.Products.Commands.CreateProduct;

public sealed record CreateProductCommandResponse(
    string Id,
    string Name,
    string CategoryId,
    string BrandId,
    string Model,
    string Description,
    string Url,
    decimal Price,
    int Stock,
    DateTime CreatedAt);