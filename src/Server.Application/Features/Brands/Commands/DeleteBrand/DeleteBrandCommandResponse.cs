namespace Server.Application.Features.Brands.Commands.DeleteBrand;

public sealed record DeleteBrandCommandResponse(
    string Id,
    string Name,
    DateTime CreatedAt);
