using Microsoft.EntityFrameworkCore;
using Server.Domain.Entities;
using Server.Domain.Repositories;
using Server.Infrastructure.Context;

namespace Server.Infrastructure.Repositories;

public sealed class CartItemQueryRepository : QueryRepository<CartItem>, ICartItemQueryRepository
{
    public CartItemQueryRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<List<CartItem>> GetAllByUser(string appUserId, CancellationToken cancellationToken = default)
    {
        return await context.Set<CartItem>().Where(p => p.AppUserId == appUserId).ToListAsync(cancellationToken);
    }

    public async Task<bool> IsCartItemExists(string appUserId, string productId, CancellationToken cancellationToken = default)
    {
        return await context.Set<CartItem>().AnyAsync(p => p.AppUserId == appUserId && p.ProductId == productId, cancellationToken);
    }
}

public sealed class CartItemCommandRepository : CommandRepository<CartItem>, ICartItemCommandRepository
{
    public CartItemCommandRepository(AppDbContext context) : base(context)
    {
    }
}