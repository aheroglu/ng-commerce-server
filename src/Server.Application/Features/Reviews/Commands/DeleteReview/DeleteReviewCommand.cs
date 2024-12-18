using MediatR;
using Server.Application.Common;

namespace Server.Application.Features.Reviews.Commands.DeleteReview;

public sealed record DeleteReviewCommand(
    string Id) : IRequest<Result<DeleteReviewCommandResponse>>;
