namespace Server.Application.Features.Products.Commands.DeleteProductById;

public sealed record DeleteProductByIdCommandResponse(
    string Id,
    string Name,
    string CategoryId,
    string BrandId,
    string Model,
    string Description,
    string Url,
    decimal Price,
    int Stock,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
