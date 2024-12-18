using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Application.Features.CartItems.Commands.ClearCartByUser;
using Server.Application.Features.CartItems.Commands.CreateCartItem;
using Server.Application.Features.CartItems.Commands.DecreaseCartItemQuantity;
using Server.Application.Features.CartItems.Commands.DeleteCartItem;
using Server.Application.Features.CartItems.Commands.IncreaseCartItemQuantity;
using Server.Application.Features.CartItems.Queries.GetCartItemsByUser;
using Server.Presentation.Abstractions;

namespace Server.Presentation.Controllers;

[AllowAnonymous]
public sealed class CartItemsController : ApiController
{
    public CartItemsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> GetAllByUser(string appUserId, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new GetCartItemsByUserQuery(appUserId), cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCartItemCommand request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }


    [HttpPost]
    public async Task<IActionResult> IncreaseQuantity(string cartItemId, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new IncreaseCartItemQuantityCommand(cartItemId), cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> DecreaseQuantity(string cartItemId, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new DecreaseCartItemQuantityCommand(cartItemId), cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(string cartItemId, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new DeleteCartItemCommand(cartItemId), cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Clear(string appUserId, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new ClearCartByUserCommand(appUserId), cancellationToken);
        return Ok(response);
    }
}