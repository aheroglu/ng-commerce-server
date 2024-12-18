using Mapster;
using MediatR;
using Server.Application.Common;
using Server.Domain.Entities;
using Server.Domain.Repositories;

namespace Server.Application.Features.Reviews.Queries.GetAllReviews;

internal sealed class GetAllReviewsQueryHandler(
    IQueryRepository<Review> queryRepository) : IRequestHandler<GetAllReviewsQuery, Result<List<GetAllReviewsQueryResponse>>>
{
    public async Task<Result<List<GetAllReviewsQueryResponse>>> Handle(GetAllReviewsQuery request, CancellationToken cancellationToken)
    {
        var reviews = await queryRepository
            .GetAllAsync(cancellationToken, p => p.AppUser, p => p.Product);

        return Result<List<GetAllReviewsQueryResponse>>
            .Success(reviews.Adapt<List<GetAllReviewsQueryResponse>>());
    }
}
