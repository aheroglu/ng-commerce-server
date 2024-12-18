using Mapster;
using MediatR;
using Server.Application.Common;
using Server.Application.Services;
using Server.Domain.Entities;
using Server.Domain.Repositories;

namespace Server.Application.Features.Products.Commands.DeleteProductById;

public sealed class DeleteProductByIdCommandHandler(
    ICommandRepository<Product> commandRepository,
    IQueryRepository<Product> queryRepository,
    IUnitOfWork unitOfWork,
    ICacheService cacheService) : IRequestHandler<DeleteProductByIdCommand, Result<DeleteProductByIdCommandResponse>>
{
    public async Task<Result<DeleteProductByIdCommandResponse>> Handle(DeleteProductByIdCommand request, CancellationToken cancellationToken)
    {
        Product product = await queryRepository
            .GetByAsync(p => p.Id == request.Id, cancellationToken);

        commandRepository
            .Delete(product);

        await unitOfWork
            .SaveChangesAsync(cancellationToken);

        cacheService
            .Remove("getallproducts");

        cacheService
            .Remove("product_" + request.Id);

        return Result<DeleteProductByIdCommandResponse>
            .Success(
                "Product was successfully deleted",
                product.Adapt<DeleteProductByIdCommandResponse>());
    }
}
