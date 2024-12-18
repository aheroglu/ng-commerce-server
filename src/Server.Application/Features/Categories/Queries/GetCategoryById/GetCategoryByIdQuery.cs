using MediatR;
using Server.Application.Common;

namespace Server.Application.Features.Categories.Queries.GetCategoryById;

public sealed record GetCategoryByIdQuery(
    string Id) : IRequest<Result<GetCategoryByIdQueryResponse>>;
