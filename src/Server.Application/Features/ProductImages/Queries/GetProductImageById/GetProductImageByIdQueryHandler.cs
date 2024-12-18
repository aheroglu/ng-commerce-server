using Mapster;
using MediatR;
using Server.Application.Common;
using Server.Domain.Entities;
using Server.Domain.Repositories;

namespace Server.Application.Features.ProductImages.Queries.GetProductImageById;

internal sealed class GetProductImageByIdQueryHandler(
    IQueryRepository<ProductImage> queryRepository) : IRequestHandler<GetProductImageByIdQuery, Result<GetProductImageByIdQueryResponse>>
{
    public async Task<Result<GetProductImageByIdQueryResponse>> Handle(GetProductImageByIdQuery request, CancellationToken cancellationToken)
    {
        ProductImage productImage = await queryRepository
            .GetByAsync(p => p.Id == request.Id, cancellationToken, p => p.Product);

        if (productImage is null) return Result<GetProductImageByIdQueryResponse>
                .Failure("Product image not found!");

        return Result<GetProductImageByIdQueryResponse>
            .Success(productImage.Adapt<GetProductImageByIdQueryResponse>());
    }
}
