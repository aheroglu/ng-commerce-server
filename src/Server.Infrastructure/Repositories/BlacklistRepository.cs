using Microsoft.EntityFrameworkCore;
using Server.Domain.Entities;
using Server.Domain.Repositories;
using Server.Infrastructure.Context;

namespace Server.Infrastructure.Repositories;

public sealed class BlacklistQueryRepository : QueryRepository<Blacklist>, IBlacklistQueryRepository
{
    public BlacklistQueryRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<bool> IsUserExistsAsync(string appUserId, CancellationToken cancellationToken = default)
    {
        return await context.Set<Blacklist>().AnyAsync(p => p.AppUserId == appUserId, cancellationToken);
    }
}

public sealed class BlacklistCommandRepository : CommandRepository<Blacklist>, IBlacklistCommandRepository
{
    public BlacklistCommandRepository(AppDbContext context) : base(context)
    {
    }
}