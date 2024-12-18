using MediatR;
using Microsoft.AspNetCore.Mvc;
using Server.Application.Features.CreditCards.Commands.CreateCreditCard;
using Server.Application.Features.CreditCards.Commands.DeleteCreditCard;
using Server.Application.Features.CreditCards.Queries.GetCreditCardsByUser;
using Server.Presentation.Abstractions;

namespace Server.Presentation.Controllers;

public sealed class CreditCardsController : ApiController
{
    public CreditCardsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> GetAllByUser(string appUserId, CancellationToken cancellationToken)
    {
        var respones = await mediator.Send(new GetCreditCardsByUserQuery(appUserId), cancellationToken);
        return Ok(respones);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCreditCardCommand request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new DeleteCreditCardCommand(id), cancellationToken);
        return Ok(response);
    }
}
