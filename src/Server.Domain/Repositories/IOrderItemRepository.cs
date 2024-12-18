using Server.Domain.Entities;

namespace Server.Domain.Repositories;

public interface IOrderItemQueryRepository : IQueryRepository<OrderItem>
{
    Task<List<OrderItem>> GetOrderItemsByOrder(string orderId, CancellationToken cancellationToken = default);
}

public interface IOrderItemCommandRepository : ICommandRepository<OrderItem> { }