using MediatR;
using Server.Application.Common;

namespace Server.Application.Features.Reviews.Commands.CreateReview;

public sealed record CreateReviewCommand(
    string Content,
    int Rating,
    string ProductId,
    string AppUserId) : IRequest<Result<CreateReviewCommandResponse>>;
