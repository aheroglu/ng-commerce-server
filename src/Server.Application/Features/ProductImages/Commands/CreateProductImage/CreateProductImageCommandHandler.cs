using Mapster;
using MediatR;
using Server.Application.Common;
using Server.Application.Services;
using Server.Domain.Entities;
using Server.Domain.Repositories;

namespace Server.Application.Features.ProductImages.Commands.CreateProductImage;

internal sealed class CreateProductImageCommandHandler(
    ICommandRepository<ProductImage> commandRepository,
    IUnitOfWork unitOfWork,
    IFileService fileService,
    ICacheService cacheService) : IRequestHandler<CreateProductImageCommand, Result<CreateProductImageCommandResponse>>
{
    public async Task<Result<CreateProductImageCommandResponse>> Handle(CreateProductImageCommand request, CancellationToken cancellationToken)
    {
        string image = fileService
            .FileSaveToServer(request.Image, "wwwroot/images/products/");

        ProductImage productImage = new()
        {
            Image = image,
            ProductId = request.ProductId,
        };

        await commandRepository
            .CreateAsync(productImage, cancellationToken);

        await unitOfWork
            .SaveChangesAsync(cancellationToken);

        cacheService
            .Remove("getallproducts");

        cacheService
            .Remove("product_" + request.ProductId);

        return Result<CreateProductImageCommandResponse>
            .Success(
                "Image was successfully created",
                productImage.Adapt<CreateProductImageCommandResponse>());
    }
}