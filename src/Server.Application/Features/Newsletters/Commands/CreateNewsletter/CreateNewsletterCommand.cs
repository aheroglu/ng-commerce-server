using MediatR;
using Server.Application.Common;

namespace Server.Application.Features.Newsletters.Commands.CreateNewsletter;

public sealed record CreateNewsletterCommand(
    string Email) : IRequest<Result<CreateNewsletterCommandResponse>>;
