using Mapster;
using MediatR;
using Server.Application.Common;
using Server.Application.Services;
using Server.Domain.Entities;
using Server.Domain.Repositories;

namespace Server.Application.Features.ProductImages.Commands.DeleteProductImage;

internal sealed class DeleteProductImageCommandHandler(
    ICommandRepository<ProductImage> productImageCommandRepository,
    IQueryRepository<ProductImage> productImageQueryRepository,
    IUnitOfWork unitOfWork,
    IFileService fileService,
    ICacheService cacheService) : IRequestHandler<DeleteProductImageCommand, Result<DeleteProductImageCommandResponse>>
{
    public async Task<Result<DeleteProductImageCommandResponse>> Handle(DeleteProductImageCommand request, CancellationToken cancellationToken)
    {
        ProductImage productImage = await productImageQueryRepository
            .GetByAsync(p => p.Id == request.Id, cancellationToken);

        if (productImage is null) return Result<DeleteProductImageCommandResponse>
                .Failure("Image not found!");

        productImageCommandRepository
            .Delete(productImage);

        fileService
            .FileDeleteFromServer("wwwroot/images/products/" + productImage.Image);

        await unitOfWork
            .SaveChangesAsync(cancellationToken);

        cacheService
            .Remove("getallproducts");

        cacheService
            .Remove("product_" + productImage.ProductId);

        return Result<DeleteProductImageCommandResponse>
            .Success(
                "Image was successfully deleted",
                productImage.Adapt<DeleteProductImageCommandResponse>());
    }
}
