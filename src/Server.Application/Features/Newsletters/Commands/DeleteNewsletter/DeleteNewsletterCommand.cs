using MediatR;
using Server.Application.Common;

namespace Server.Application.Features.Newsletters.Commands.DeleteNewsletter;

public sealed record DeleteNewsletterCommand(
    string Email) : IRequest<Result<DeleteNewsletterCommandResponse>>;