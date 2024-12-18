using MediatR;

namespace Server.Application.Features.OrderItems.Commands.CreateOrderItem;

public sealed record CreateOrderItemCommand(
    string OrderId,
    string ProductId,
    short Quantity,
    decimal TotalPrice) : IRequest;
