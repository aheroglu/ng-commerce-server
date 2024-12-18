using MediatR;
using Server.Application.Common;

namespace Server.Application.Features.Brands.Queries.GetAllBrands;

public sealed record GetAllBrandsQuery : IRequest<Result<List<GetAllBrandsQueryResponse>>>;
