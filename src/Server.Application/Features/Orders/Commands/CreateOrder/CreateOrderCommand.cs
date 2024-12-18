using MediatR;
using Server.Application.Common;
using Server.Domain.Enums;

namespace Server.Application.Features.Orders.Commands.CreateOrder;

public sealed record CreateOrderCommand(
    string AppUserId,
    string AddressId,
    string CreditCardId,
    OrderStatus OrderStatus,
    decimal TotalPrice) : IRequest<Result<string>>;
