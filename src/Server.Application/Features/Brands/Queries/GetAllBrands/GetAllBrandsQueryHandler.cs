using MapsterMapper;
using MediatR;
using Server.Application.Common;
using Server.Application.Services;
using Server.Domain.Entities;
using Server.Domain.Repositories;

namespace Server.Application.Features.Brands.Queries.GetAllBrands;

internal sealed class GetAllBrandsQueryHandler(
    IQueryRepository<Brand> queryRepository,
    IMapper mapper,
    ICacheService cacheService) : IRequestHandler<GetAllBrandsQuery, Result<List<GetAllBrandsQueryResponse>>>
{
    private static string key = "getallbrands";
    private static TimeSpan expiration = TimeSpan.FromMinutes(10);

    public async Task<Result<List<GetAllBrandsQueryResponse>>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
    {
        var cachedBrands = cacheService
            .Get<List<GetAllBrandsQueryResponse>>(key);

        if (cachedBrands is not null) return Result<List<GetAllBrandsQueryResponse>>
                .Success(cachedBrands);

        var brands = mapper
            .Map<List<GetAllBrandsQueryResponse>>(await queryRepository
            .GetAllAsync(cancellationToken));

        cacheService
            .Set(key, brands, expiration);

        return Result<List<GetAllBrandsQueryResponse>>
            .Success(brands);
    }
}
