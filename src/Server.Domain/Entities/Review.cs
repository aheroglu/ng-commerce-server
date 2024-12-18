using Server.Domain.Abstractions;

namespace Server.Domain.Entities;

public sealed class Review : Entity
{
    public string Content { get; set; } = default!;
    public byte Rating { get; set; } = default!;
    public string ProductId { get; set; } = default!;
    public Product Product { get; set; } = default!;
    public string AppUserId { get; set; } = default!;
    public AppUser AppUser { get; set; } = default!;
}
