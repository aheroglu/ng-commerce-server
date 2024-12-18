using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Server.Application.Common;
using Server.Domain.Entities;

namespace Server.Application.Features.Profile.Commands.UpdateProfile;

internal sealed class UpdateProfileCommandHandler(
    UserManager<AppUser> userManager,
    IMapper mapper) : IRequestHandler<UpdateProfileCommand, Result<UpdateProfileCommandResponse>>
{
    public async Task<Result<UpdateProfileCommandResponse>> Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
    {
        AppUser? user = await userManager
            .Users
            .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

        if (user is null) return Result<UpdateProfileCommandResponse>
                .Failure("User not found!");

        mapper.Map(request, user);
        user.UserName = request.Email;

        await userManager
               .UpdateAsync(user);

        return Result<UpdateProfileCommandResponse>
            .Success(
                "Your profile was successfully updated",
                user.Adapt<UpdateProfileCommandResponse>());
    }
}
