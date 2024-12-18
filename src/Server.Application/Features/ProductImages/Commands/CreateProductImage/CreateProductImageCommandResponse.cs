namespace Server.Application.Features.ProductImages.Commands.CreateProductImage;

public sealed record CreateProductImageCommandResponse(
    string Id,
    string Image,
    string ProductId,
    DateTime CreatedAt);
