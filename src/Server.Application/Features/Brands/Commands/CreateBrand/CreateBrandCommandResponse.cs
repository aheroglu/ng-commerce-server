namespace Server.Application.Features.Brands.Commands.CreateBrand;

public sealed record CreateBrandCommandResponse(
    string Id,
    string Name,
    DateTime CreatedAt);
