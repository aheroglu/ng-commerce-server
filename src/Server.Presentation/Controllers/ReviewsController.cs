using MediatR;
using Microsoft.AspNetCore.Mvc;
using Server.Application.Features.Reviews.Commands.CreateReview;
using Server.Application.Features.Reviews.Commands.DeleteReview;
using Server.Application.Features.Reviews.Commands.UpdateReview;
using Server.Application.Features.Reviews.Queries.GetAllReviews;
using Server.Application.Features.Reviews.Queries.GetReviewById;
using Server.Presentation.Abstractions;

namespace Server.Presentation.Controllers;

public sealed class ReviewsController : ApiController
{
    public ReviewsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new GetAllReviewsQuery(), cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> GetById(string id, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new GetReviewByIdQuery(id), cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateReviewCommand request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new DeleteReviewCommand(id), cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateReviewCommand request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}