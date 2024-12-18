using Server.Domain.Abstractions;

namespace Server.Domain.Entities;

public sealed class Newsletter : Entity
{
    public string Email { get; set; } = default!;
}
