namespace Server.Application.Features.Messages.Commands.DeleteMessage;

public sealed record DeleteMessageCommandResponse(
    string Id,
    string Name,
    string Email,
    string Topic,
    string Content,
    DateTime CreatedAt);
