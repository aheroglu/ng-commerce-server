using Microsoft.EntityFrameworkCore;
using Server.Domain.Entities;
using Server.Domain.Repositories;
using Server.Infrastructure.Context;

namespace Server.Infrastructure.Repositories;

public sealed class CreditCardQueryRepository : QueryRepository<CreditCard>, ICreditCardQueryRepository
{
    public CreditCardQueryRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<List<CreditCard>> GetAllCreditCardsByUser(string appUserId, CancellationToken cancellationToken = default)
    {
        return await context.Set<CreditCard>().Include(p => p.AppUser).Where(p => p.AppUserId == appUserId).ToListAsync(cancellationToken);
    }

    public async Task<bool> IsCreditCardExists(string appUserId, string number, string expirationMonth, string expirationYear, string CVV, CancellationToken cancellationToken = default)
    {
        return await context.Set<CreditCard>().AnyAsync(p => p.AppUserId == appUserId && p.Number == number && p.ExpirationMonth == expirationMonth && p.ExpirationYear == expirationYear && p.CVV == CVV, cancellationToken);
    }
}

public sealed class CreditCardCommandRepository : CommandRepository<CreditCard>, ICreditCardCommandRepository
{
    public CreditCardCommandRepository(AppDbContext context) : base(context)
    {
    }
}
