namespace Server.Application.Features.Categories.Queries.GetCategoryById;

public sealed record GetCategoryByIdQueryResponse(
    string Id,
    string Name,
    string Image,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
