using Mapster;
using MediatR;
using Server.Application.Common;
using Server.Domain.Entities;
using Server.Domain.Repositories;

namespace Server.Application.Features.Reviews.Queries.GetReviewById;

internal sealed class GetReviewByIdQueryHandler(
    IQueryRepository<Review> queryRepository) : IRequestHandler<GetReviewByIdQuery, Result<GetReviewByIdQueryResponse>>
{
    public async Task<Result<GetReviewByIdQueryResponse>> Handle(GetReviewByIdQuery request, CancellationToken cancellationToken)
    {
        Review review = await queryRepository
            .GetByAsync(p => p.Id == request.Id, cancellationToken, p => p.AppUser, p => p.Product);

        if (review is null) return Result<GetReviewByIdQueryResponse>
                .Failure("Review not found!");

        return Result<GetReviewByIdQueryResponse>
            .Success(review.Adapt<GetReviewByIdQueryResponse>());
    }
}
