using MediatR;
using Server.Application.Common;

namespace Server.Application.Features.Products.Queries.GetProductByUrl;

public sealed record GetProductByUrlQuery(
    string Url) : IRequest<Result<GetProductByUrlQueryResponse>>;
