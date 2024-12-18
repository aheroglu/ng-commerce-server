using MediatR;
using Server.Application.Common;

namespace Server.Application.Features.Messages.Commands.CreateMessage;

public sealed record CreateMessageCommand(
    string Name,
    string Email,
    string Topic,
    string Content) : IRequest<Result<CreateMessageCommandResponse>>;
