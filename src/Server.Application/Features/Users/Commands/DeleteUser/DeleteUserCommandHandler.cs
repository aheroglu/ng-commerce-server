using Mapster;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Server.Application.Common;
using Server.Application.Services;
using Server.Domain.Entities;

namespace Server.Application.Features.Users.Commands.DeleteUser;

public sealed class DeleteUserCommandHandler(
    UserManager<AppUser> userManager,
    IEmailService emailService) : IRequestHandler<DeleteUserCommand, Result<DeleteUserCommandResponse>>
{
    public async Task<Result<DeleteUserCommandResponse>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        AppUser? user = await userManager
            .FindByEmailAsync(request.Email);

        if (user is null) return Result<DeleteUserCommandResponse>
                .Failure("User not found!");

        var result = await userManager
             .DeleteAsync(user);

        if (result.Errors.Any()) return Result<DeleteUserCommandResponse>
                .Failure(result.Errors.Select(p => p.Description).ToList());

        string body = @"
        <h1>Your NG-Commerce Account Was Deleted</h1>
        <p>Your NG-Commerce account was deleted. We will miss you. See you later again.</p>";

        emailService
            .SendEmail(
                user.FullName,
                request.Email,
                "Your Account Deleted",
                body);

        return Result<DeleteUserCommandResponse>
            .Success(
                "User was successfully deleted",
                user.Adapt<DeleteUserCommandResponse>());
    }
}
