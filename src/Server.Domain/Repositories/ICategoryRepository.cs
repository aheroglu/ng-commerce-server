using Server.Domain.Entities;

namespace Server.Domain.Repositories;

public interface ICategoryQueryRepository : IQueryRepository<Category>
{
    Task<bool> IsCategoryExistsAsync(string name, CancellationToken cancellationToken = default);
}

public interface ICategoryCommandRepository : ICommandRepository<Category> { }