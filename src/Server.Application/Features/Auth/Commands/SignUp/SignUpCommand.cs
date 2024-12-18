using MediatR;
using Server.Application.Common;

namespace Server.Application.Features.Auth.Commands.SignUp;

public sealed record SignUpCommand(
    string FullName,
    string Email,
    string Password) : IRequest<Result<SignUpCommandResponse>>;