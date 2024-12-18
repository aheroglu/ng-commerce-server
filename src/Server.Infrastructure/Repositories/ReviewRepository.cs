using Microsoft.EntityFrameworkCore;
using Server.Domain.Entities;
using Server.Domain.Repositories;
using Server.Infrastructure.Context;

namespace Server.Infrastructure.Repositories;

public sealed class ReviewQueryRepository : QueryRepository<Review>, IReviewQueryRepository
{
    public ReviewQueryRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<bool> IsReviewExistsAsync(string appUserId, string productId, CancellationToken cancellationToken = default)
    {
        return await context.Set<Review>().AnyAsync(p => p.AppUserId == appUserId && p.ProductId == productId, cancellationToken);
    }
}

public sealed class ReviewCommandRepository : CommandRepository<Review>, IReviewCommandRepository
{
    public ReviewCommandRepository(AppDbContext context) : base(context)
    {
    }
}