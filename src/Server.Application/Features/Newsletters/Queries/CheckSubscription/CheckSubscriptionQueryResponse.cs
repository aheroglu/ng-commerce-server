namespace Server.Application.Features.Newsletters.Queries.CheckSubscription;

public sealed record CheckSubscriptionQueryResponse(
    string Id,
    string Email,
    DateTime CreatedAt);
