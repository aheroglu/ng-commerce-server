namespace Server.Application.Features.Brands.Queries.GetAllBrands;

public sealed record GetAllBrandsQueryResponse(
    string Id,
    string Name,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
