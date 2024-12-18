using MediatR;
using Microsoft.AspNetCore.Mvc;
using Server.Application.Features.Addresses.Commands.CreateAddress;
using Server.Application.Features.Addresses.Commands.DeleteAddress;
using Server.Application.Features.Addresses.Commands.UpdateAddress;
using Server.Application.Features.Addresses.Queries.GetAddressById;
using Server.Application.Features.Addresses.Queries.GetAllAddressesByUser;
using Server.Presentation.Abstractions;

namespace Server.Presentation.Controllers;
public sealed class AddressesController : ApiController
{
    public AddressesController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> GetAllByUser(string appUserId, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new GetAllAddressesByUserQuery(appUserId), cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> GetById(string id, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new GetAddressByIdQuery(id), cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateAddressCommand request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }


    [HttpPost]
    public async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new DeleteAddressCommand(id), cancellationToken);
        return Ok(response);
    }


    [HttpPost]
    public async Task<IActionResult> Update(UpdateAddressCommand request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}