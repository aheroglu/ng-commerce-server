using Server.Domain.Entities;

namespace Server.Domain.Repositories;

public interface ICartItemQueryRepository : IQueryRepository<CartItem>
{
    Task<bool> IsCartItemExists(string appUserId, string productId, CancellationToken cancellationToken = default);
    Task<List<CartItem>> GetAllByUser(string appUserId, CancellationToken cancellationToken = default);
}

public interface ICartItemCommandRepository : ICommandRepository<CartItem> { }