namespace Server.Application.Features.Auth.Commands.SignIn;

public sealed record SignInCommandResponse(
    string Id,
    string UserName,
    string Email);
