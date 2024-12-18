using Mapster;
using MediatR;
using Server.Application.Common;
using Server.Application.Services;
using Server.Domain.Entities;
using Server.Domain.Repositories;

namespace Server.Application.Features.Products.Queries.GetProductByUrl;

internal sealed class GetProductByUrlQueryHandler(
    IQueryRepository<Product> queryRepository,
    ICacheService cacheService) : IRequestHandler<GetProductByUrlQuery, Result<GetProductByUrlQueryResponse>>
{
    private static string key = "product_";
    private static TimeSpan expiration = TimeSpan.FromMinutes(10);

    public async Task<Result<GetProductByUrlQueryResponse>> Handle(GetProductByUrlQuery request, CancellationToken cancellationToken)
    {
        var cachedProduct = cacheService
            .Get<GetProductByUrlQueryResponse>(key + request.Url);

        if (cachedProduct is not null) return Result<GetProductByUrlQueryResponse>
            .Success(cachedProduct);

        Product product = await queryRepository
            .GetByAsync(
                p => p.Url == request.Url,
                cancellationToken,
                p => p.Category,
                p => p.Brand,
                p => p.ProductImages);

        if (product is null) return Result<GetProductByUrlQueryResponse>
                .Failure("Product not found!");

        cacheService
            .Set(key + request.Url, product, expiration);

        return Result<GetProductByUrlQueryResponse>
            .Success(product.Adapt<GetProductByUrlQueryResponse>());
    }
}
