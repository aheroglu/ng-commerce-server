using Microsoft.EntityFrameworkCore;
using Server.Domain.Entities;
using Server.Domain.Repositories;
using Server.Infrastructure.Context;

namespace Server.Infrastructure.Repositories;

public sealed class OrderQueryRepository : QueryRepository<Order>, IOrderQueryRepository
{
    public OrderQueryRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<List<Order>> GetOrdersByUser(string appUserId, CancellationToken cancellationToken = default)
    {
        return await context.Set<Order>().Include(p => p.AppUser).Include(p => p.Address).Include(p => p.CreditCard).Where(p => p.AppUserId == appUserId).ToListAsync(cancellationToken);
    }
}

public sealed class OrderCommandRepository : CommandRepository<Order>, IOrderCommandRepository
{
    public OrderCommandRepository(AppDbContext context) : base(context)
    {
    }
}
