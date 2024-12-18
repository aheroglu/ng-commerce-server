namespace Server.Application.Features.Newsletters.Commands.DeleteNewsletter;

public sealed record DeleteNewsletterCommandResponse(
    string Id,
    string Email,
    DateTime CreatedAt);