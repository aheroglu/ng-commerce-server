using Server.Domain.Abstractions;

namespace Server.Domain.Entities;

public sealed class CreditCard : Entity
{
    public string AppUserId { get; set; } = default!;
    public AppUser AppUser { get; set; } = default!;
    public string HolderName { get; set; } = default!;
    public string Number { get; set; } = default!;
    public string ExpirationMonth { get; set; } = default!;
    public string ExpirationYear { get; set; } = default!;
    public string CVV { get; set; } = default!;

    public ICollection<Order> Orders { get; set; } = new List<Order>();
}