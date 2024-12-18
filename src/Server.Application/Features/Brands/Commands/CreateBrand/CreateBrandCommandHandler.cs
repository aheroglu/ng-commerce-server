using Mapster;
using MediatR;
using Server.Application.Common;
using Server.Application.Services;
using Server.Domain.Entities;
using Server.Domain.Repositories;

namespace Server.Application.Features.Brands.Commands.CreateBrand;

internal sealed class CreateBrandCommandHandler(
    IBrandQueryRepository brandQueryRepository,
    IBrandCommandRepository brandCommandRepository,
    IUnitOfWork unitOfWork,
    ICacheService cacheService) : IRequestHandler<CreateBrandCommand, Result<CreateBrandCommandResponse>>
{
    public async Task<Result<CreateBrandCommandResponse>> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
    {
        bool isBrandNameExists = await brandQueryRepository
            .IsBrandExistsAsync(request.Name, cancellationToken);

        if (isBrandNameExists) return Result<CreateBrandCommandResponse>
                .Failure("Brand name already exists!");

        Brand brand = new()
        {
            Name = request.Name
        };

        await brandCommandRepository
            .CreateAsync(brand, cancellationToken);

        await unitOfWork
            .SaveChangesAsync(cancellationToken);

        cacheService
            .Remove("getallbrands");

        return Result<CreateBrandCommandResponse>
            .Success(
                "Brand was succesfully created",
                brand.Adapt<CreateBrandCommandResponse>());
    }
}
