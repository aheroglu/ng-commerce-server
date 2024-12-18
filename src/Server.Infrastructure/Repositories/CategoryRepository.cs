using Microsoft.EntityFrameworkCore;
using Server.Domain.Entities;
using Server.Domain.Repositories;
using Server.Infrastructure.Context;

namespace Server.Infrastructure.Repositories;

public sealed class CategoryQueryRepository : QueryRepository<Category>, ICategoryQueryRepository
{
    public CategoryQueryRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<bool> IsCategoryExistsAsync(string name, CancellationToken cancellationToken = default)
    {
        return await context.Set<Category>().AnyAsync(p => p.Name == name, cancellationToken);
    }
}

public sealed class CategoryCommandRepository : CommandRepository<Category>, ICategoryCommandRepository
{
    public CategoryCommandRepository(AppDbContext context) : base(context)
    {
    }
}