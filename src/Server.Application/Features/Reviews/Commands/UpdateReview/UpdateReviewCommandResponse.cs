namespace Server.Application.Features.Reviews.Commands.UpdateReview;

public sealed record UpdateReviewCommandResponse(
    string Id,
    string Content,
    int Rating,
    string ProductId,
    string AppUserId,
    DateTime CreatedAt);
