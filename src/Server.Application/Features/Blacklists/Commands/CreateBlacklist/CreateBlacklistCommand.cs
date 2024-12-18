using MediatR;
using Server.Application.Common;

namespace Server.Application.Features.Blacklists.Commands.CreateBlacklist;

public sealed record CreateBlacklistCommand(
    string AppUserId,
    string Reason) : IRequest<Result<CreateBlacklistCommandResponse>>;
