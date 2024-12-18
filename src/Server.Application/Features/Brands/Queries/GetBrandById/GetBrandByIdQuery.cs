using MediatR;
using Server.Application.Common;

namespace Server.Application.Features.Brands.Queries.GetBrandById;

public sealed record GetBrandByIdQuery(
    string Id) : IRequest<Result<GetBrandByIdQueryResponse>>;
