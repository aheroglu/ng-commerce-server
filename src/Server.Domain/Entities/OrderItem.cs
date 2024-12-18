using Server.Domain.Abstractions;

namespace Server.Domain.Entities;

public sealed class OrderItem : Entity
{
    public string OrderId { get; set; } = default!;
    public Order Order { get; set; } = default!;
    public string ProductId { get; set; } = default!;
    public Product Product { get; set; } = default!;
    public short Quantity { get; set; }
    public decimal TotalPrice { get; set; }
}