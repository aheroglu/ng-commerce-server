using MediatR;
using Microsoft.AspNetCore.Mvc;
using Server.Application.Features.Newsletters.Commands.CreateNewsletter;
using Server.Application.Features.Newsletters.Commands.DeleteNewsletter;
using Server.Application.Features.Newsletters.Queries.CheckSubscription;
using Server.Application.Features.Newsletters.Queries.GetAllNewsletters;
using Server.Presentation.Abstractions;

namespace Server.Presentation.Controllers;
public sealed class NewslettersController : ApiController
{
    public NewslettersController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new GetAllNewslettersQuery(), cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> CheckSubscription(CheckSubscriptionQuery request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateNewsletterCommand request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(string email, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new DeleteNewsletterCommand(email), cancellationToken);
        return Ok(response);
    }
}
