using Mapster;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Server.Application.Common;
using Server.Application.Services;
using Server.Domain.Entities;

namespace Server.Application.Features.Auth.Commands.SignIn;

public sealed class SignInCommandHandler(
    UserManager<AppUser> userManager,
    IJwtProvider jwtProvider,
    IEmailService emailService) : IRequestHandler<SignInCommand, Result<SignInCommandResponse>>
{
    public async Task<Result<SignInCommandResponse>> Handle(SignInCommand request, CancellationToken cancellationToken)
    {
        AppUser? user = await userManager
            .Users
            .FirstOrDefaultAsync(p => p.UserName == request.UserNameOrEmail || p.Email == request.UserNameOrEmail, cancellationToken);

        if (user is null) return Result<SignInCommandResponse>
                .Failure("User not found!");

        if (user.IsBlocked)
        {
            string body = @"
            <h1>Your NG-Commerce Account Has Been Blocked</h1>
            <p>Your account has been blocked. If you think something went wrong, please contact us.</p>";

            emailService
                .SendEmail(
                    user.FullName,
                    user.Email!,
                    "Your Account Blocked",
                    body);

            return Result<SignInCommandResponse>
                .Failure("Account blocked!");
        }

        bool IsPasswordCorrect = await userManager
            .CheckPasswordAsync(user, request.Password);

        if (!IsPasswordCorrect) return Result<SignInCommandResponse>
                .Failure("Incorrect password!");

        string token = await jwtProvider.GenerateToken(user);

        return Result<SignInCommandResponse>
            .Success(token, user.Adapt<SignInCommandResponse>());
    }
}
