using Mapster;
using MediatR;
using Server.Application.Common;
using Server.Application.Services;
using Server.Domain.Entities;
using Server.Domain.Repositories;

namespace Server.Application.Features.Products.Queries.GetProductById;

public sealed class GetProductByIdQueryHandler(
    IQueryRepository<Product> queryRepository,
    ICacheService cacheService) : IRequestHandler<GetProductByIdQuery, Result<GetProductByIdQueryResponse>>
{
    private static string key = "product_";
    private static TimeSpan expiration = TimeSpan.FromMinutes(10);

    public async Task<Result<GetProductByIdQueryResponse>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var cachedProduct = cacheService
            .Get<GetProductByIdQueryResponse>(key + request.Id);

        if (cachedProduct is not null) return Result<GetProductByIdQueryResponse>
                .Success(cachedProduct);

        Product product = await queryRepository
            .GetByAsync(
                p => p.Id == request.Id,
                cancellationToken,
                p => p.Category,
                p => p.Brand,
                p => p.ProductImages);

        if (product is null) return Result<GetProductByIdQueryResponse>
                .Failure("Product not found!");

        cacheService
            .Set(key + request.Id, product, expiration);

        return Result<GetProductByIdQueryResponse>
            .Success(product.Adapt<GetProductByIdQueryResponse>());
    }
}
