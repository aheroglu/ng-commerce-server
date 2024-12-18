namespace Server.Application.Features.Users.Queries.GetAllUsers;

public sealed record GetAllUsersQueryResponse(
    string Id,
    string FullName,
    string Email,
    string Role,
    bool IsBlocked);