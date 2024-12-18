using MediatR;
using Server.Application.Common;

namespace Server.Application.Features.Reviews.Commands.UpdateReview;

public sealed record UpdateReviewCommand(
    string Id,
    string Content,
    int Rating,
    string ProductId,
    string AppUserId) : IRequest<Result<UpdateReviewCommandResponse>>;
