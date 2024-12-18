namespace Server.Application.Features.Brands.Queries.GetBrandById;

public sealed record GetBrandByIdQueryResponse(
    string Id,
    string Name,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
