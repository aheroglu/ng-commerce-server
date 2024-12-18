using Server.Domain.Abstractions;

namespace Server.Domain.Entities;

public sealed class ProductImage : Entity
{
    public string Image { get; set; } = default!;
    public string ProductId { get; set; } = default!;
    public Product Product { get; set; } = default!;
}
