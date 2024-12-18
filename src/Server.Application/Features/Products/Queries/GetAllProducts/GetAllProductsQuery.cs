using MediatR;
using Server.Application.Common;

namespace Server.Application.Features.Products.Queries.GetAllProducts;

public sealed record GetAllProductsQuery : IRequest<Result<List<GetAllProductsQueryResponse>>>;