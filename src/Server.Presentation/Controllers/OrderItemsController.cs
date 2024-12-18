using MediatR;
using Microsoft.AspNetCore.Mvc;
using Server.Application.Features.OrderItems.Commands.CreateOrderItem;
using Server.Application.Features.OrderItems.Queries.GetAllOrderItemsByOrder;
using Server.Presentation.Abstractions;

namespace Server.Presentation.Controllers;

public sealed class OrderItemsController : ApiController
{
    public OrderItemsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> GetAllByOrder(string orderId, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new GetAllOrderItemsByOrderQuery(orderId), cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateOrderItemCommand request, CancellationToken cancellationToken)
    {
        await mediator.Send(request, cancellationToken);
        return Ok();
    }
}