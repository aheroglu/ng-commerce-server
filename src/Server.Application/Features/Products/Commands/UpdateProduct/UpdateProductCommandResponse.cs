namespace Server.Application.Features.Products.Commands.UpdateProduct;

public sealed record UpdateProductCommandResponse(
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