using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Application.Features.Products.Commands.CreateProduct;
using Server.Application.Features.Products.Commands.DeleteProductById;
using Server.Application.Features.Products.Commands.UpdateProduct;
using Server.Application.Features.Products.Queries.GetAllProducts;
using Server.Application.Features.Products.Queries.GetProductById;
using Server.Application.Features.Products.Queries.GetProductByUrl;
using Server.Presentation.Abstractions;

namespace Server.Presentation.Controllers;

public sealed class ProductsController : ApiController
{
    public ProductsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new GetAllProductsQuery(), cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> GetById(string id, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new GetProductByIdQuery(id), cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> GetByUrl(string url, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new GetProductByUrlQuery(url), cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new DeleteProductByIdCommand(id), cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}