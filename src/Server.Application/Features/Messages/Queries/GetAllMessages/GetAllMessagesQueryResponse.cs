namespace Server.Application.Features.Messages.Queries.GetAllMessages;

public sealed record GetAllMessagesQueryResponse(
    string Id,
    string Name,
    string Email,
    string Topic,
    string Content,
    DateTime CreatedAt,
    DateTime? UpdatedAt);