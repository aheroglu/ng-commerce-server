namespace Server.Application.Features.Messages.Queries.GetMessageById;

public sealed record GetMessageByIdQueryResponse(
    string Id,
    string Name,
    string Email,
    string Topic,
    string Content,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
