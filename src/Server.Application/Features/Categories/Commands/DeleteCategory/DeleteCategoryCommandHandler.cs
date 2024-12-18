using Mapster;
using MediatR;
using Server.Application.Common;
using Server.Application.Services;
using Server.Domain.Entities;
using Server.Domain.Repositories;

namespace Server.Application.Features.Categories.Commands.DeleteCategory;

internal sealed class DeleteCategoryCommandHandler(
    IQueryRepository<Category> queryRepository,
    ICommandRepository<Category> commandRepository,
    IUnitOfWork unitOfWork,
    IFileService fileService,
    ICacheService cacheService) : IRequestHandler<DeleteCategoryCommand, Result<DeleteCategoryCommandResponse>>
{
    public async Task<Result<DeleteCategoryCommandResponse>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        Category category = await queryRepository
            .GetByAsync(p => p.Id == request.Id, cancellationToken);

        if (category is null) return Result<DeleteCategoryCommandResponse>
                .Failure("Category not found!");

        commandRepository
            .Delete(category);

        fileService
            .FileDeleteFromServer("wwwroot/images/app/" + category.Image);

        await unitOfWork
            .SaveChangesAsync(cancellationToken);

        cacheService
            .Remove("getallcategories");

        cacheService
            .Remove("category_" + request.Id);

        return Result<DeleteCategoryCommandResponse>
            .Success(
                "Category was sucessfully deleted",
                category.Adapt<DeleteCategoryCommandResponse>());
    }
}