using Mapster;
using MapsterMapper;
using MediatR;
using Server.Application.Common;
using Server.Domain.Entities;
using Server.Domain.Repositories;

namespace Server.Application.Features.Reviews.Commands.CreateReview;

internal sealed class CreateReviewCommandHandler(
    IReviewQueryRepository reviewQueryRepository,
    IReviewCommandRepository reviewCommandRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<CreateReviewCommand, Result<CreateReviewCommandResponse>>
{
    public async Task<Result<CreateReviewCommandResponse>> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
    {
        bool isReviewExists = await reviewQueryRepository
                .IsReviewExistsAsync(request.AppUserId, request.ProductId, cancellationToken);

        if (isReviewExists) return Result<CreateReviewCommandResponse>
                .Failure("You have already evaluated this product");

        Review review = mapper.Map<Review>(request);

        await reviewCommandRepository
            .CreateAsync(review, cancellationToken);

        await unitOfWork
            .SaveChangesAsync(cancellationToken);

        return Result<CreateReviewCommandResponse>
            .Success(
                "Review was successfully added",
                review.Adapt<CreateReviewCommandResponse>());
    }
}
