namespace Server.Application.Features.Brands.Commands.UpdateBrand;

public sealed record UpdateBrandCommandResponse(
    string Id,
    string Name,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
