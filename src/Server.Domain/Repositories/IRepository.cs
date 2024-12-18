using Server.Domain.Abstractions;
using System.Linq.Expressions;

namespace Server.Domain.Repositories;

public interface ICommandRepository<T> where T : Entity
{
    Task CreateAsync(T entity, CancellationToken cancellationToken = default);
    void Update(T entity);
    void Delete(T entity);
}

public interface IQueryRepository<T> where T : Entity
{
    IQueryable<T> QueryAll();
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includes);
    Task<T> GetByAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includes);
}