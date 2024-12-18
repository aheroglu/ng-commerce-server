using Microsoft.EntityFrameworkCore;
using Server.Domain.Entities;
using Server.Domain.Repositories;
using Server.Infrastructure.Context;

namespace Server.Infrastructure.Repositories;

public sealed class BrandQueryRepository : QueryRepository<Brand>, IBrandQueryRepository
{
    public BrandQueryRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<bool> IsBrandExistsAsync(string name, CancellationToken cancellationToken = default)
    {
        return await context.Set<Brand>().AnyAsync(p => p.Name == name, cancellationToken);
    }
}

public sealed class BrandCommandRepository : CommandRepository<Brand>, IBrandCommandRepository
{
    public BrandCommandRepository(AppDbContext context) : base(context)
    {
    }
}
