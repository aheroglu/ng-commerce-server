using MediatR;
using Server.Application.Common;

namespace Server.Application.Features.Products.Queries.GetProductById;

public sealed record GetProductByIdQuery(
    string Id) : IRequest<Result<GetProductByIdQueryResponse>>;