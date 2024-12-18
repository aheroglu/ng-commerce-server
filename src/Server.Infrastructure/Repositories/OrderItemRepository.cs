using Microsoft.EntityFrameworkCore;
using Server.Domain.Entities;
using Server.Domain.Repositories;
using Server.Infrastructure.Context;

namespace Server.Infrastructure.Repositories;

public sealed class OrderItemQueryRepository : QueryRepository<OrderItem>, IOrderItemQueryRepository
{
    public OrderItemQueryRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<List<OrderItem>> GetOrderItemsByOrder(string orderId, CancellationToken cancellationToken = default)
    {
        return await context.Set<OrderItem>().Include(p => p.Order).Include(p => p.Product).ThenInclude(p => p.ProductImages).Where(p => p.Order.OrderId == orderId).ToListAsync(cancellationToken);
    }
}

public sealed class OrderItemCommandRepository : CommandRepository<OrderItem>, IOrderItemCommandRepository
{
    public OrderItemCommandRepository(AppDbContext context) : base(context)
    {
    }
}
