using Server.Domain.Abstractions;
using Server.Domain.Enums;

namespace Server.Domain.Entities;

public sealed class Order : Entity
{
    public Order()
    {
        OrderId = GenerateOrderId();
    }

    public string OrderId { get; set; } = default!;
    public string AppUserId { get; set; } = default!;
    public AppUser AppUser { get; set; } = default!;
    public OrderStatus OrderStatus { get; set; }
    public decimal TotalPrice { get; set; }
    public string AddressId { get; set; } = default!;
    public Address Address { get; set; } = default!;
    public string CreditCardId { get; set; } = default!;
    public CreditCard CreditCard { get; set; } = default!;

    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    private string GenerateOrderId()
    {
        var random = new Random();
        return random.Next(1000000000, 1999999999).ToString();
    }
}