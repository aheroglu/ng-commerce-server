namespace Server.Application.Features.Reviews.Commands.DeleteReview;

public sealed record DeleteReviewCommandResponse(
    string Id,
    string ProductId,
    string AppUserId,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
