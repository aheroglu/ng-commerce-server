namespace Server.Application.Dtos;

public sealed record CreditCardDto(
    string Id,
    string AppUserId,
    AppUserDto AppUser,
    string HolderName,
    string Number,
    string ExpirationMonth,
    string ExpirationYear,
    string CVV);