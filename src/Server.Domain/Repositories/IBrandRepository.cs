using Server.Domain.Entities;

namespace Server.Domain.Repositories;

public interface IBrandQueryRepository : IQueryRepository<Brand>
{
    Task<bool> IsBrandExistsAsync(string name, CancellationToken cancellationToken = default);
}

public interface IBrandCommandRepository : ICommandRepository<Brand> { }