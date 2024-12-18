using MapsterMapper;
using MediatR;
using Server.Application.Common;
using Server.Application.Services;
using Server.Domain.Entities;
using Server.Domain.Repositories;

namespace Server.Application.Features.Categories.Queries.GetAllCategories;

internal sealed class GetAllCategoriesQueryHandler(
    IQueryRepository<Category> queryRepository,
    IMapper mapper,
    ICacheService cacheService) : IRequestHandler<GetAllCategoriesQuery, Result<List<GetAllCategoriesQueryResponse>>>
{
    private static string key = "getallcategories";
    private static TimeSpan expiration = TimeSpan.FromMinutes(10);

    public async Task<Result<List<GetAllCategoriesQueryResponse>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        var cachedCategories = cacheService
            .Get<List<GetAllCategoriesQueryResponse>>(key);

        if (cachedCategories is not null) return Result<List<GetAllCategoriesQueryResponse>>
                .Success(cachedCategories);

        var categories = mapper
            .Map<List<GetAllCategoriesQueryResponse>>(await queryRepository
            .GetAllAsync());

        cacheService.Set(key, categories, expiration);

        return Result<List<GetAllCategoriesQueryResponse>>
            .Success(categories);
    }
}