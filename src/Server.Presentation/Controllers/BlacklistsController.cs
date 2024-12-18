using MediatR;
using Microsoft.AspNetCore.Mvc;
using Server.Application.Features.Blacklists.Commands.CreateBlacklist;
using Server.Application.Features.Blacklists.Commands.DeleteBlacklist;
using Server.Application.Features.Blacklists.Commands.UpdateBlacklist;
using Server.Application.Features.Blacklists.Queries.GetAllBlacklist;
using Server.Application.Features.Blacklists.Queries.GetBlacklistById;
using Server.Presentation.Abstractions;

namespace Server.Presentation.Controllers;

public sealed class BlacklistsController : ApiController
{
    public BlacklistsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new GetAllBlacklistQuery(), cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> GetById(string id, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new GetBlacklistByIdQuery(id), cancellationToken);
        return Ok(response);
    }


    [HttpPost]
    public async Task<IActionResult> Create(CreateBlacklistCommand request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new DeleteBlacklistCommand(id), cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateBlacklistCommand request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}