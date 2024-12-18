namespace Server.Application.Features.Newsletters.Queries.GetAllNewsletters;

public sealed record GetAllNewslettersQueryResponse(
    string Id,
    string Email,
    DateTime CreatedAt);
