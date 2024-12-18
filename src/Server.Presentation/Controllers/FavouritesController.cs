using MediatR;
using Microsoft.AspNetCore.Mvc;
using Server.Application.Features.Favourites.Commands.CreateFavourite;
using Server.Application.Features.Favourites.Commands.DeleteFavourite;
using Server.Application.Features.Favourites.Queries.GetAllFavouritesByUser;
using Server.Application.Features.Favourites.Queries.GetFavouriteById;
using Server.Presentation.Abstractions;

namespace Server.Presentation.Controllers;

public sealed class FavouritesController : ApiController
{
    public FavouritesController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> GetAllByUser(string appUserId, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new GetAllFavouritesByUserQuery(appUserId), cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> GetById(string id, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new GetFavouriteByIdQuery(id), cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateFavouriteCommand request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }


    [HttpPost]
    public async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new DeleteFavouriteCommand(id), cancellationToken);
        return Ok(response);
    }
}