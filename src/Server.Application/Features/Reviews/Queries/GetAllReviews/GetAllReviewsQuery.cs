using MediatR;
using Server.Application.Common;

namespace Server.Application.Features.Reviews.Queries.GetAllReviews;

public sealed record GetAllReviewsQuery : IRequest<Result<List<GetAllReviewsQueryResponse>>>;
