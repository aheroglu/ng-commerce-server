using Mapster;
using MediatR;
using Server.Application.Common;
using Server.Application.Services;
using Server.Domain.Entities;
using Server.Domain.Repositories;

namespace Server.Application.Features.Categories.Commands.CreateCategory;

internal sealed class CreateCategoryCommandHandler(
    ICategoryQueryRepository categoryQueryRepository,
    ICategoryCommandRepository categoryCommandRepository,
    IFileService fileService,
    IUnitOfWork unitOfWork,
    ICacheService cacheService) : IRequestHandler<CreateCategoryCommand, Result<CreateCategoryCommandResponse>>
{
    public async Task<Result<CreateCategoryCommandResponse>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        bool isCategoryNameExists = await categoryQueryRepository
            .IsCategoryExistsAsync(request.Name, cancellationToken);

        if (isCategoryNameExists) return Result<CreateCategoryCommandResponse>
                .Failure("Categrory already exists!");

        string image = fileService
            .FileSaveToServer(request.Image, "wwwroot/images/categories/");

        Category category = new()
        {
            Name = request.Name,
            Image = image
        };

        await categoryCommandRepository
             .CreateAsync(category, cancellationToken);

        await unitOfWork
            .SaveChangesAsync(cancellationToken);

        cacheService
            .Remove("getallcategories");

        return Result<CreateCategoryCommandResponse>
            .Success(
                "Category was sucessfully created",
                category.Adapt<CreateCategoryCommandResponse>());
    }
}
