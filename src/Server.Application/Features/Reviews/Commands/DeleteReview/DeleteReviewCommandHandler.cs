using Mapster;
using MediatR;
using Server.Application.Common;
using Server.Domain.Entities;
using Server.Domain.Repositories;

namespace Server.Application.Features.Reviews.Commands.DeleteReview;

internal sealed class DeleteReviewCommandHandler(
    IQueryRepository<Review> queryRepository,
    ICommandRepository<Review> commandRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteReviewCommand, Result<DeleteReviewCommandResponse>>
{
    public async Task<Result<DeleteReviewCommandResponse>> Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
    {
        Review review = await queryRepository
            .GetByAsync(p => p.Id == request.Id, cancellationToken);

        if (review is null) return Result<DeleteReviewCommandResponse>
                .Failure("Review not found!");

        commandRepository
            .Delete(review);

        await unitOfWork
            .SaveChangesAsync(cancellationToken);

        return Result<DeleteReviewCommandResponse>
            .Success(
                "Review was successfully deleted",
                review.Adapt<DeleteReviewCommandResponse>());
    }
}
