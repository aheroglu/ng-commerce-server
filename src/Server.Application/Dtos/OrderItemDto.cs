namespace Server.Application.Dtos;

public sealed record OrderItemDto(
    string Id,
    string OrderId,
    OrderDto Order,
    string ProductId,
    ProductDto Product,
    short Quantity,
    decimal TotalPrice);