namespace Server.Application.Features.Messages.Commands.CreateMessage;

public sealed record CreateMessageCommandResponse(
    string Id,
    string Name,
    string Email,
    string Topic,
    string Content,
    DateTime CreatedAt);
