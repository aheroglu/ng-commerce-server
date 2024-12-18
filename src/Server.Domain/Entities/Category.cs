using Server.Domain.Abstractions;

namespace Server.Domain.Entities;
public sealed class Category : Entity
{
    public string Name { get; set; } = default!;
    public string Image { get; set; } = default!;

    public ICollection<Product> Products { get; set; } = new List<Product>();
}
