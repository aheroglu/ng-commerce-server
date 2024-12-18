using Server.Application.Dtos;

namespace Server.Application.Features.OrderItems.Queries.GetAllOrderItemsByOrder;

public sealed record GetAllOrderItemsByOrderQueryResponse(
    string Id,
    string OrderId,
    OrderDto Order,
    string ProductId,
    ProductDto Product,
    short Quantity,
    decimal TotalPrice);
