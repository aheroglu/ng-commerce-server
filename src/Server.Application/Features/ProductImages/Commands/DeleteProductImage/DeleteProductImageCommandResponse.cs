namespace Server.Application.Features.ProductImages.Commands.DeleteProductImage;

public sealed record DeleteProductImageCommandResponse(
    string Id,
    string ProductId,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
