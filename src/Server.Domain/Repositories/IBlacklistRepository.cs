using Server.Domain.Entities;

namespace Server.Domain.Repositories;

public interface IBlacklistQueryRepository : IQueryRepository<Blacklist>
{
    Task<bool> IsUserExistsAsync(string appUserId, CancellationToken cancellationToken = default);
}

public interface IBlacklistCommandRepository : ICommandRepository<Blacklist> { }