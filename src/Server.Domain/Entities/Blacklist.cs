using Server.Domain.Abstractions;

namespace Server.Domain.Entities;

public sealed class Blacklist : Entity
{
    public string AppUserId { get; set; } = default!;
    public AppUser AppUser { get; set; } = default!;
    public string Reason { get; set; } = default!;
}