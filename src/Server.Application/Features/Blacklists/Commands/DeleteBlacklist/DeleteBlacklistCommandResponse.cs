using Server.Application.Dtos;

namespace Server.Application.Features.Blacklists.Commands.DeleteBlacklist;

public sealed record DeleteBlacklistCommandResponse(
    string Id,
    string AppUserId,
    AppUserDto AppUser,
    string Reason,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
