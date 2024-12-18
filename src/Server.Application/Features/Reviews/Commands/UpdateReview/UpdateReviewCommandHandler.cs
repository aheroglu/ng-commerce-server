using Mapster;
using MapsterMapper;
using MediatR;
using Server.Application.Common;
using Server.Domain.Entities;
using Server.Domain.Repositories;

namespace Server.Application.Features.Reviews.Commands.UpdateReview;

internal sealed class UpdateReviewCommandHandler(
    ICommandRepository<Review> commandRepository,
    IQueryRepository<Review> queryRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateReviewCommand, Result<UpdateReviewCommandResponse>>
{
    public async Task<Result<UpdateReviewCommandResponse>> Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
    {
        Review review = await queryRepository
            .GetByAsync(p => p.Id == request.Id, cancellationToken);

        if (review is null) return Result<UpdateReviewCommandResponse>
                .Failure("Review not found!");

        mapper.Map(request, review);

        commandRepository
            .Update(review);

        await unitOfWork
            .SaveChangesAsync(cancellationToken);

        return Result<UpdateReviewCommandResponse>
            .Success(
                "Review was successfully updated",
                review.Adapt<UpdateReviewCommandResponse>());
    }
}
