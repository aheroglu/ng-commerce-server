using Server.Application.Dtos;

namespace Server.Application.Features.Blacklists.Queries.GetBlacklistById;

public sealed record GetBlacklistByIdQueryResponse(
    string Id,
    string AppUserId,
    AppUserDto AppUser,
    string Reason,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
