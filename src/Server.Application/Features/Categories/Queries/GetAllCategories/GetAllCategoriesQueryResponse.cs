namespace Server.Application.Features.Categories.Queries.GetAllCategories;

public sealed record GetAllCategoriesQueryResponse(
    string Id,
    string Name,
    string Image,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
