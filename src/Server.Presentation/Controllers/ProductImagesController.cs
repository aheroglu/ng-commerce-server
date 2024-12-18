using MediatR;
using Microsoft.AspNetCore.Mvc;
using Server.Application.Features.ProductImages.Commands.CreateProductImage;
using Server.Application.Features.ProductImages.Commands.DeleteProductImage;
using Server.Application.Features.ProductImages.Queries.GetProductImageById;
using Server.Application.Features.ProductImages.Queries.GetProductImagesByProduct;
using Server.Presentation.Abstractions;

namespace Server.Presentation.Controllers;

public sealed class ProductImagesController : ApiController
{
    public ProductImagesController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> GetAllByProduct(string productId, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new GetAllProductImagesByProductCommand(productId), cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> GetById(string id, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new GetProductImageByIdQuery(id), cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromForm] CreateProductImageCommand request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new DeleteProductImageCommand(id), cancellationToken);
        return Ok(response);
    }
}