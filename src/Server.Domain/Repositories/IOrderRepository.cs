using Server.Domain.Entities;

namespace Server.Domain.Repositories;

public interface IOrderQueryRepository : IQueryRepository<Order>
{
    Task<List<Order>> GetOrdersByUser(string appUserId, CancellationToken cancellationToken = default);
}

public interface IOrderCommandRepository : ICommandRepository<Order> { }