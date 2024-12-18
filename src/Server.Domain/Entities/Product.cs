using Server.Domain.Abstractions;

namespace Server.Domain.Entities;

public sealed class Product : Entity
{
    public string Name { get; set; } = default!;
    public string CategoryId { get; set; } = default!;
    public Category Category { get; set; } = default!;
    public string BrandId { get; set; } = default!;
    public Brand Brand { get; set; } = default!;
    public string Model { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Url { get; set; } = default!;
    public decimal Price { get; set; }
    public int Stock { get; set; }

    public ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();
    public ICollection<Favourite> Favourites { get; set; } = new List<Favourite>();
    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    public ICollection<Review> Reviews { get; set; } = new List<Review>();
}