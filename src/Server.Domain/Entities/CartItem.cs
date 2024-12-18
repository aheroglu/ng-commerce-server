using Server.Domain.Abstractions;

namespace Server.Domain.Entities;

public sealed class CartItem : Entity
{
    public string AppUserId { get; set; } = default!;
    public AppUser AppUser { get; set; } = default!;
    public string ProductId { get; set; } = default!;
    public Product Product { get; set; } = default!;
    public short Quantity { get; set; }
}