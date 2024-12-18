using Server.Domain.Abstractions;

namespace Server.Domain.Entities;

public sealed class Address : Entity
{
    public string AppUserId { get; set; } = default!;
    public AppUser AppUser { get; set; } = default!;
    public string Street { get; set; } = default!;
    public string City { get; set; } = default!;
    public string District { get; set; } = default!;
    public string PostalCode { get; set; } = default!;
    public string FullAddress { get; set; } = default!;
    public string AddressType { get; set; } = default!;

    public ICollection<Order> Orders { get; set; } = new List<Order>();
}