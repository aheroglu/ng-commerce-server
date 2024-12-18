namespace Server.Application.Features.Users.Queries.GetUserById;

public sealed record GetUserByIdQueryResponse(
    string Id,
    string FullName,
    string Email,
    string PhoneNumber,
    DateOnly BirthDate,
    bool IsBlocked);