using Mapster;
using MediatR;
using Server.Application.Common;
using Server.Domain.Entities;
using Server.Domain.Repositories;

namespace Server.Application.Features.Newsletters.Queries.CheckSubscription;

internal sealed class CheckSubscriptionQueryHandler(
    IQueryRepository<Newsletter> queryRepository) : IRequestHandler<CheckSubscriptionQuery, Result<CheckSubscriptionQueryResponse>>
{
    public async Task<Result<CheckSubscriptionQueryResponse>> Handle(CheckSubscriptionQuery request, CancellationToken cancellationToken)
    {
        Newsletter newsletter = await queryRepository
            .GetByAsync(p => p.Email == request.Email, cancellationToken);

        if (newsletter is null) return Result<CheckSubscriptionQueryResponse>
                .Failure("Not found!");

        return Result<CheckSubscriptionQueryResponse>
            .Success(newsletter.Adapt<CheckSubscriptionQueryResponse>());
    }
}
