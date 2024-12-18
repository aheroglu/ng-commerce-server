using Server.Application.Dtos;
using Server.Domain.Enums;

namespace Server.Application.Features.Orders.Queries.GetOrderById;

public sealed record GetOrderByIdQueryResponse(
    string Id,
    string OrderId,
    string AppUserId,
    AppUserDto AppUser,
    OrderStatus OrderStatus,
    decimal TotalPrice,
    string AddressId,
    AddressDto Address,
    string CreditCardId,
    CreditCardDto CreditCard,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
