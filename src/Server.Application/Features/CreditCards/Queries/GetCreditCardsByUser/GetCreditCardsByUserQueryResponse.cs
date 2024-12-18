using Server.Application.Dtos;

namespace Server.Application.Features.CreditCards.Queries.GetCreditCardsByUser;

public sealed record GetCreditCardsByUserQueryResponse(
    string Id,
    string AppUserId,
    AppUserDto AppUser,
    string HolderName,
    string Number,
    string ExpirationMonth,
    string ExpirationYear,
    string CVV,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
