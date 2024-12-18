using Server.Domain.Entities;

namespace Server.Domain.Repositories;

public interface INewsletterQueryRepository : IQueryRepository<Newsletter>
{
    Task<bool> IsEmailExistsAsync(string email, CancellationToken cancellationToken = default);
}

public interface INewsletterCommandRepository : ICommandRepository<Newsletter> { }