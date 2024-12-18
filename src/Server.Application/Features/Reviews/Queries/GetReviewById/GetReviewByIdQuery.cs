using MediatR;
using Server.Application.Common;

namespace Server.Application.Features.Reviews.Queries.GetReviewById;

public sealed record GetReviewByIdQuery(
    string Id) : IRequest<Result<GetReviewByIdQueryResponse>>;
