using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Application.Features.Brands.Commands.CreateBrand;
using Server.Application.Features.Brands.Commands.DeleteBrand;
using Server.Application.Features.Brands.Commands.UpdateBrand;
using Server.Application.Features.Brands.Queries.GetAllBrands;
using Server.Application.Features.Brands.Queries.GetBrandById;
using Server.Presentation.Abstractions;

namespace Server.Presentation.Controllers;

public sealed class BrandsController : ApiController
{
    public BrandsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new GetAllBrandsQuery(), cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> GetById(string id, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new GetBrandByIdQuery(id), cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateBrandCommand request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }


    [HttpPost]
    public async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new DeleteBrandCommand(id), cancellationToken);
        return Ok(response);
    }


    [HttpPost]
    public async Task<IActionResult> Update(UpdateBrandCommand request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}
