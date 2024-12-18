namespace Server.Application.Features.Categories.Commands.UpdateCategory;

public sealed record UpdateCategoryCommandResponse(
    string Id,
    string Name,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
