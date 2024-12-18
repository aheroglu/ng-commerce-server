using MediatR;
using Microsoft.AspNetCore.Mvc;
using Server.Application.Features.Profile.Commands.UpdatePassword;
using Server.Application.Features.Profile.Commands.UpdateProfile;
using Server.Presentation.Abstractions;

namespace Server.Presentation.Controllers;
public sealed class ProfileController : ApiController
{
    public ProfileController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> UpdateProfile(UpdateProfileCommand request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> UpdatePassword(UpdatePasswordCommand request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}