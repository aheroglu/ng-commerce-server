using Server.Domain.Enums;

namespace Server.Application.Dtos;

public sealed record OrderDto(
    string Id,
    string AppUserId,
    AppUserDto AppUser,
    OrderStatus OrderStatus,
    decimal TotalPrice,
    string AddressId,
    AddressDto AddressDto,
    string CreditCardId,
    CreditCardDto CreditCard);