using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Application.Features.Users.Commands.DeleteUser;
using Server.Application.Features.Users.Queries.GetAllCustomers;
using Server.Application.Features.Users.Queries.GetAllUsers;
using Server.Application.Features.Users.Queries.GetUserById;
using Server.Presentation.Abstractions;

namespace Server.Presentation.Controllers;

[Authorize(Policy = "AdminOnly")]
public sealed class UsersController : ApiController
{
    public UsersController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new GetAllUsersQuery(), cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> GetById(string appUserId, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new GetUserByIdQuery(appUserId), cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> GetAllCustomers(CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new GetAllCustomersQuery(), cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(string email, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new DeleteUserCommand(email), cancellationToken);
        return Ok(response);
    }
}