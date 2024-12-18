using MediatR;
using Server.Application.Common;

namespace Server.Application.Features.Newsletters.Queries.CheckSubscription;

public sealed record CheckSubscriptionQuery(
    string Email) : IRequest<Result<CheckSubscriptionQueryResponse>>;
