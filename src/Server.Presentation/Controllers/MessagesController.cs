using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Application.Features.Messages.Commands.CreateMessage;
using Server.Application.Features.Messages.Commands.DeleteMessage;
using Server.Application.Features.Messages.Queries.GetAllMessages;
using Server.Application.Features.Messages.Queries.GetMessageById;
using Server.Presentation.Abstractions;

namespace Server.Presentation.Controllers;

public sealed class MessagesController : ApiController
{
    public MessagesController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new GetAllMessagesQuery(), cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> GetById(string id, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new GetMessageByIdQuery(id), cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Create(CreateMessageCommand request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new DeleteMessageCommand(id), cancellationToken);
        return Ok(response);
    }
}
