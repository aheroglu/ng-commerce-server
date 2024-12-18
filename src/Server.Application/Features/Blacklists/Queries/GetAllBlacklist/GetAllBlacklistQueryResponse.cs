using Server.Application.Dtos;

namespace Server.Application.Features.Blacklists.Queries.GetAllBlacklist;

public sealed record GetAllBlacklistQueryResponse(
    string Id,
    string AppUserId,
    AppUserDto AppUser,
    string Reason,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
