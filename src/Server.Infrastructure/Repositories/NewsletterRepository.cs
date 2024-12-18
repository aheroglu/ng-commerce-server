using Microsoft.EntityFrameworkCore;
using Server.Domain.Entities;
using Server.Domain.Repositories;
using Server.Infrastructure.Context;

namespace Server.Infrastructure.Repositories;

public sealed class NewsletterQueryRepository : QueryRepository<Newsletter>, INewsletterQueryRepository
{
    public NewsletterQueryRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<bool> IsEmailExistsAsync(string email, CancellationToken cancellationToken = default)
    {
        return await context.Set<Newsletter>().AnyAsync(p => p.Email == email, cancellationToken);
    }
}

public sealed class NewsletterCommandRepository : CommandRepository<Newsletter>, INewsletterCommandRepository
{
    public NewsletterCommandRepository(AppDbContext context) : base(context)
    {
    }
}