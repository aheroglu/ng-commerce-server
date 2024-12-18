namespace Server.Application.Features.Reviews.Commands.CreateReview;

public sealed record CreateReviewCommandResponse(
    string Id,
    string Content,
    int Rating,
    string ProductId,
    string AppUserId,
    DateTime CreatedAt);