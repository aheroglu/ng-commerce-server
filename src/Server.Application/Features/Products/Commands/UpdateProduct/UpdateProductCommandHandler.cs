using Mapster;
using MediatR;
using Server.Application.Common;
using Server.Application.Services;
using Server.Domain.Entities;
using Server.Domain.Repositories;

namespace Server.Application.Features.Products.Commands.UpdateProduct;

public sealed class UpdateProductCommandHandler(
    IProductCommandRepository productCommandRepository,
    IProductQueryRepository productQueryRepository,
    IUnitOfWork unitOfWork,
    ICacheService cacheService) : IRequestHandler<UpdateProductCommand, Result<UpdateProductCommandResponse>>
{
    public async Task<Result<UpdateProductCommandResponse>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        Product product = await productQueryRepository
            .GetByAsync(p => p.Id == request.Id, cancellationToken);

        if (product is null) return Result<UpdateProductCommandResponse>
                .Failure("Product not found!");

        if (product.Name != request.Name)
        {
            bool isNameExists = await productQueryRepository
                .IsProductExistsAsync(request.Name, cancellationToken);

            if (isNameExists) return Result<UpdateProductCommandResponse>
                .Failure("Product name already exists!");
        }

        request.Adapt(product);

        productCommandRepository
            .Update(product);

        await unitOfWork
            .SaveChangesAsync(cancellationToken);

        cacheService
            .Remove("getallproducts");

        cacheService
            .Remove("product_" + request.Id);

        return Result<UpdateProductCommandResponse>
            .Success(
                "Product was successfully updated",
                product.Adapt<UpdateProductCommandResponse>());
    }
}