using MediatR;
using Server.Application.Common;

namespace Server.Application.Features.Messages.Commands.DeleteMessage;

public sealed record DeleteMessageCommand(
    string Id) : IRequest<Result<DeleteMessageCommandResponse>>;
