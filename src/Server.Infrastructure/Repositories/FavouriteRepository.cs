using Microsoft.EntityFrameworkCore;
using Server.Domain.Entities;
using Server.Domain.Repositories;
using Server.Infrastructure.Context;

namespace Server.Infrastructure.Repositories;

public sealed class FavouriteQueryRepository : QueryRepository<Favourite>, IFavouriteQueryRepository
{
    public FavouriteQueryRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<bool> IsFavouriteExists(string productId, string appUserId, CancellationToken cancellationToken = default)
    {
        return await context.Set<Favourite>().AnyAsync(p => p.ProductId == productId && p.AppUserId == appUserId, cancellationToken);
    }
}


public sealed class FavouriteCommandRepository : CommandRepository<Favourite>, IFavouriteCommandRepository
{
    public FavouriteCommandRepository(AppDbContext context) : base(context)
    {
    }
}
