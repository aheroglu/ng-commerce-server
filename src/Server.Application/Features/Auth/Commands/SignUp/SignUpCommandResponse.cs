namespace Server.Application.Features.Auth.Commands.SignUp;

public sealed record SignUpCommandResponse(
    string Id,
    string UserName,
    string Email);
