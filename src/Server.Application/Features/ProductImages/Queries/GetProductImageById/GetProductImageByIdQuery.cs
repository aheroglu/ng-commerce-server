using MediatR;
using Server.Application.Common;

namespace Server.Application.Features.ProductImages.Queries.GetProductImageById;

public sealed record GetProductImageByIdQuery(
    string Id) : IRequest<Result<GetProductImageByIdQueryResponse>>;
