using Server.Application.Dtos;

namespace Server.Application.Features.Blacklists.Commands.UpdateBlacklist;

public sealed record UpdateBlacklistCommandResponse(
    string Id,
    string AppUserId,
    AppUserDto AppUser,
    string Reason,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
