using MapsterMapper;
using MediatR;
using Server.Application.Common;
using Server.Application.Services;
using Server.Domain.Entities;
using Server.Domain.Repositories;

namespace Server.Application.Features.Brands.Queries.GetBrandById;

internal sealed class GetBrandByIdQueryHandler(
    IQueryRepository<Brand> queryRepository,
    IMapper mapper,
    ICacheService cacheService) : IRequestHandler<GetBrandByIdQuery, Result<GetBrandByIdQueryResponse>>
{
    private static string key = "brand_";
    private static TimeSpan expiration = TimeSpan.FromMinutes(10);

    public async Task<Result<GetBrandByIdQueryResponse>> Handle(GetBrandByIdQuery request, CancellationToken cancellationToken)
    {
        var cachedBrand = cacheService
            .Get<GetBrandByIdQueryResponse>(key + request.Id);

        if (cachedBrand is not null) return Result<GetBrandByIdQueryResponse>
                .Success(cachedBrand);

        var brand = mapper
            .Map<GetBrandByIdQueryResponse>(await queryRepository
            .GetByAsync(p => p.Id == request.Id, cancellationToken));

        if (brand is null) return Result<GetBrandByIdQueryResponse>
                .Failure("Brand not found!");

        cacheService
            .Set(key + brand.Id, brand, expiration);

        return Result<GetBrandByIdQueryResponse>
            .Success(brand);
    }
}