using Mapster;
using MapsterMapper;
using MediatR;
using Server.Application.Common;
using Server.Application.Services;
using Server.Domain.Entities;
using Server.Domain.Repositories;

namespace Server.Application.Features.Brands.Commands.UpdateBrand;

internal sealed class UpdateBrandCommandHandler(
    IBrandCommandRepository brandCommandRepository,
    IBrandQueryRepository brandQueryRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper,
    ICacheService cacheService) : IRequestHandler<UpdateBrandCommand, Result<UpdateBrandCommandResponse>>
{
    public async Task<Result<UpdateBrandCommandResponse>> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
    {
        Brand brand = await brandQueryRepository
            .GetByAsync(p => p.Id == request.Id, cancellationToken);

        if (brand is null) return Result<UpdateBrandCommandResponse>
                .Failure("Brand not found!");

        if (request.Name != brand.Name)
        {
            bool isBrandNameExists = await brandQueryRepository
                .IsBrandExistsAsync(request.Name, cancellationToken);

            if (isBrandNameExists) return Result<UpdateBrandCommandResponse>
                    .Failure("Brand name already exists!");
        }

        mapper.Map(request, brand);

        brandCommandRepository
            .Update(brand);

        await unitOfWork
            .SaveChangesAsync(cancellationToken);

        cacheService
            .Remove("getallbrands");

        cacheService
            .Remove("brand_" + request.Id);

        return Result<UpdateBrandCommandResponse>
            .Success(
                "Brand was successfully updated",
                brand.Adapt<UpdateBrandCommandResponse>());
    }
}
