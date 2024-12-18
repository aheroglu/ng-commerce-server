using MediatR;
using Server.Application.Common;

namespace Server.Application.Features.Blacklists.Commands.UpdateBlacklist;

public sealed record UpdateBlacklistCommand(
    string Id,
    string Reason) : IRequest<Result<UpdateBlacklistCommandResponse>>;
