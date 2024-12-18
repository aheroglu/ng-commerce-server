using MediatR;
using Microsoft.AspNetCore.Mvc;
using Server.Application.Features.Dashboard.DashboardStatistics;
using Server.Presentation.Abstractions;

namespace Server.Presentation.Controllers;

public sealed class DashboardController : ApiController
{
    public DashboardController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> GetStatistics(CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new DashboardStatisticsQuery(), cancellationToken);
        return Ok(response);
    }
}