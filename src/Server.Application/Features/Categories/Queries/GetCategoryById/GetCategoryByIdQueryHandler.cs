using MapsterMapper;
using MediatR;
using Server.Application.Common;
using Server.Application.Services;
using Server.Domain.Entities;
using Server.Domain.Repositories;

namespace Server.Application.Features.Categories.Queries.GetCategoryById;

internal sealed class GetCategoryByIdQueryHandler(
    IQueryRepository<Category> queryRepository,
    IMapper mapper,
    ICacheService cacheService) : IRequestHandler<GetCategoryByIdQuery, Result<GetCategoryByIdQueryResponse>>
{
    private static string key = "category_";
    private static TimeSpan expiration = TimeSpan.FromMinutes(10);

    public async Task<Result<GetCategoryByIdQueryResponse>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var cachedCategory = cacheService
            .Get<GetCategoryByIdQueryResponse>(key + request.Id);

        if (cachedCategory is not null) return Result<GetCategoryByIdQueryResponse>
                .Success(cachedCategory);

        var category = mapper
            .Map<GetCategoryByIdQueryResponse>(await queryRepository
            .GetByAsync(p => p.Id == request.Id, cancellationToken));

        if (category is null) return Result<GetCategoryByIdQueryResponse>
                .Failure("Category not found!");

        cacheService
            .Set(key + category.Id, category, expiration);

        return Result<GetCategoryByIdQueryResponse>
            .Success(category);
    }
}
