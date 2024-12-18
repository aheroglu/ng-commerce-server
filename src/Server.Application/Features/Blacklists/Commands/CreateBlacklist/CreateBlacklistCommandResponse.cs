using Server.Application.Dtos;

namespace Server.Application.Features.Blacklists.Commands.CreateBlacklist;

public sealed record CreateBlacklistCommandResponse(
    string AppUserId,
    AppUserDto AppUser,
    string Reason);
