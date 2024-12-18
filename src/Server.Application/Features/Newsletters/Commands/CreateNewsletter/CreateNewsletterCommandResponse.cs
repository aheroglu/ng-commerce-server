namespace Server.Application.Features.Newsletters.Commands.CreateNewsletter;

public sealed record CreateNewsletterCommandResponse(
    string Id,
    string Email,
    DateTime CreatedAt);
