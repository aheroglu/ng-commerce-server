using MediatR;
using Server.Application.Common;

namespace Server.Application.Features.Blacklists.Commands.DeleteBlacklist;

public sealed record DeleteBlacklistCommand(
    string Id) : IRequest<Result<DeleteBlacklistCommandResponse>>;
