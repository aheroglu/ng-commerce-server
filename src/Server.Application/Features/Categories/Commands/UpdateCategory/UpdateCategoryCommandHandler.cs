using Mapster;
using MapsterMapper;
using MediatR;
using Server.Application.Common;
using Server.Application.Services;
using Server.Domain.Entities;
using Server.Domain.Repositories;

namespace Server.Application.Features.Categories.Commands.UpdateCategory;

internal sealed class UpdateCategoryCommandHandler(
    ICategoryCommandRepository categoryCommandRepository,
    ICategoryQueryRepository categoryQueryRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper,
    IFileService fileService,
    ICacheService cacheService) : IRequestHandler<UpdateCategoryCommand, Result<UpdateCategoryCommandResponse>>
{
    public async Task<Result<UpdateCategoryCommandResponse>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        Category category = await categoryQueryRepository
            .GetByAsync(p => p.Id == request.Id, cancellationToken);

        string categoryImage = category.Image;

        if (category is null) return Result<UpdateCategoryCommandResponse>
                .Failure("Category not found!");

        if (request.Name != category.Name)
        {
            bool isCategoryNameExists = await categoryQueryRepository
                .IsCategoryExistsAsync(request.Name, cancellationToken);

            if (isCategoryNameExists) return Result<UpdateCategoryCommandResponse>
                    .Failure("Category already exists!");
        }

        if (request.Image is not null)
        {
            fileService
                .FileDeleteFromServer("wwwroot/images/app/" + category.Image);
        }

        if (request.Image is not null)
        {
            string image = fileService
                .FileSaveToServer(request.Image!, "wwwroot/images/app/");

            category.Image = image;
        }

        mapper.Map(request, category);

        if (request.Image is null) category.Image = categoryImage;


        categoryCommandRepository
            .Update(category);

        await unitOfWork
            .SaveChangesAsync(cancellationToken);

        cacheService
            .Remove("getallcategories");

        cacheService
            .Remove("category_" + request.Id);

        return Result<UpdateCategoryCommandResponse>
            .Success(
                "Category was successfully updated",
                category.Adapt<UpdateCategoryCommandResponse>());
    }
}
