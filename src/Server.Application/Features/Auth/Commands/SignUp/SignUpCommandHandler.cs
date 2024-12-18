using Mapster;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Server.Application.Common;
using Server.Application.Services;
using Server.Domain.Entities;

namespace Server.Application.Features.Auth.Commands.SignUp;

public sealed class SignUpCommandHandler(
    UserManager<AppUser> userManager,
    IEmailService emailService) : IRequestHandler<SignUpCommand, Result<SignUpCommandResponse>>
{
    public async Task<Result<SignUpCommandResponse>> Handle(SignUpCommand request, CancellationToken cancellationToken)
    {
        bool isEmailExists = await userManager
            .Users
            .AnyAsync(p => p.Email == request.Email, cancellationToken);

        if (isEmailExists) return Result<SignUpCommandResponse>
                .Success("Email already exists!");

        AppUser user = new()
        {
            FullName = request.FullName,
            UserName = request.Email,
            Email = request.Email
        };

        var result = await userManager
            .CreateAsync(user, request.Password);

        if (result.Errors.Any()) return Result<SignUpCommandResponse>
                .Failure(result.Errors.Select(p => p.Description).ToList());

        if (result.Succeeded)
        {
            await userManager
                .AddToRoleAsync(user, "Customer");
        }

        string body = @"
        <h1>Welcome to NG-Commerce!</h1>   
        <p>Your account created successfully, enjoy your shopping.</p>";

        emailService
           .SendEmail(
               user.FullName,
               user.Email,
               "Account Created Successfully",
               body);

        return Result<SignUpCommandResponse>
            .Success(
                "Account was successfully created. Please sign in.",
                user.Adapt<SignUpCommandResponse>());
    }
}
