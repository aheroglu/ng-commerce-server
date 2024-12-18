using Server.Domain.Entities;

namespace Server.Domain.Repositories;

public interface IFavouriteQueryRepository : IQueryRepository<Favourite>
{
    Task<bool> IsFavouriteExists(string productId, string appUserId, CancellationToken cancellationToken = default);
}

public interface IFavouriteCommandRepository : ICommandRepository<Favourite> { }