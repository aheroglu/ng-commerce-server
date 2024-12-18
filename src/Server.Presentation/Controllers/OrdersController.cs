using MediatR;
using Microsoft.AspNetCore.Mvc;
using Server.Application.Features.Orders.Commands.CreateOrder;
using Server.Application.Features.Orders.Queries.GetAllOrdersByUser;
using Server.Application.Features.Orders.Queries.GetOrderById;
using Server.Presentation.Abstractions;

namespace Server.Presentation.Controllers;
public sealed class OrdersController : ApiController
{
    public OrdersController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> GetAllByUser(string appUserId, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new GetAllOrdersByUserQuery(appUserId), cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> GetById(string orderId, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new GetOrderByIdQuery(orderId), cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}