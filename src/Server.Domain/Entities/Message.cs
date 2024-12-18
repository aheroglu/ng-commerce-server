using Server.Domain.Abstractions;

namespace Server.Domain.Entities;

public sealed class Message : Entity
{
    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Topic { get; set; } = default!;
    public string Content { get; set; } = default!;
}