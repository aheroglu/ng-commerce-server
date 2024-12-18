namespace Server.Application.Features.Categories.Commands.DeleteCategory;

public sealed record DeleteCategoryCommandResponse(
    string Id,
    string Name,
    DateTime CreatedAt);
