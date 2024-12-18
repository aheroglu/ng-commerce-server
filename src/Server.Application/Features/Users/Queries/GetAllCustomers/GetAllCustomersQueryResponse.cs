namespace Server.Application.Features.Users.Queries.GetAllCustomers;

public sealed record GetAllCustomersQueryResponse(
    string Id,
    string FullName,
    string Email,
    string Role,
    bool IsBlocked);
