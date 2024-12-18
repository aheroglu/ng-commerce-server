using Server.Domain.Entities;

namespace Server.Domain.Repositories;

public interface ICreditCardQueryRepository : IQueryRepository<CreditCard>
{
    Task<bool> IsCreditCardExists(string appUserId, string number, string expirationMonth, string expirationYear, string CVV, CancellationToken cancellationToken = default);
    Task<List<CreditCard>> GetAllCreditCardsByUser(string appUserId, CancellationToken cancellationToken = default);
}

public interface ICreditCardCommandRepository : ICommandRepository<CreditCard> { }