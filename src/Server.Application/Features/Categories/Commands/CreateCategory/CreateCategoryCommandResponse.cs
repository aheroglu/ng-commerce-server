namespace Server.Application.Features.Categories.Commands.CreateCategory;

public sealed record CreateCategoryCommandResponse(
    string Id,
    string Name,
    DateTime CreatedAt);
