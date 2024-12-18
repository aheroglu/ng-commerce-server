using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Server.Application.Common;
using Server.Domain.Entities;

namespace Server.Application.Features.Profile.Commands.UpdatePassword;

public sealed class UpdatePasswordCommandHandler(
    UserManager<AppUser> userManager) : IRequestHandler<UpdatePasswordCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdatePasswordCommand request, CancellationToken cancellationToken)
    {
        AppUser? user = await userManager
            .Users
            .FirstOrDefaultAsync(p => p.Id == request.AppUserId, cancellationToken);

        if (user is null) return Result<string>
                .Failure("User not found!");

        bool isCurrentPasswordCorrect = await userManager
            .CheckPasswordAsync(user, request.CurrentPassword);

        if (isCurrentPasswordCorrect is not true) return Result<string>
                .Failure("Your current password is wrong!");

        if (!request.NewPassword.Equals(request.ConfirmPassword)) return Result<string>
                .Failure("Passwords not match!");

        user.PasswordHash = userManager
            .PasswordHasher.HashPassword(user, request.NewPassword);

        await userManager
            .UpdateAsync(user);

        return Result<string>
            .Success("Your password was successfully updated");
    }
}