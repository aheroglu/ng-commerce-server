using Mapster;
using MediatR;
using Server.Application.Common;
using Server.Application.Services;
using Server.Domain.Entities;
using Server.Domain.Repositories;

namespace Server.Application.Features.Brands.Commands.DeleteBrand;

internal sealed class DeleteBrandCommandHandler(
    IQueryRepository<Brand> queryRepository,
    ICommandRepository<Brand> commandRepository,
    IUnitOfWork unitOfWork,
    ICacheService cacheService) : IRequestHandler<DeleteBrandCommand, Result<DeleteBrandCommandResponse>>
{
    public async Task<Result<DeleteBrandCommandResponse>> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
    {
        Brand brand = await queryRepository
            .GetByAsync(p => p.Id == request.Id);

        if (brand is null) return Result<DeleteBrandCommandResponse>
                .Failure("Brand not found!");

        commandRepository
            .Delete(brand);

        await unitOfWork
            .SaveChangesAsync(cancellationToken);

        cacheService
            .Remove("getallbrands");

        cacheService
            .Remove("brand_" + request.Id);

        return Result<DeleteBrandCommandResponse>
            .Success(
                "Brand was succesfully deleted",
                brand.Adapt<DeleteBrandCommandResponse>());
    }
}
