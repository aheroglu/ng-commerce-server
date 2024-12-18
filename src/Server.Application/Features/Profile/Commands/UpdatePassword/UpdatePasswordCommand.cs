using MediatR;
using Server.Application.Common;

namespace Server.Application.Features.Profile.Commands.UpdatePassword;

public sealed record UpdatePasswordCommand(
    string AppUserId,
    string CurrentPassword,
    string NewPassword,
    string ConfirmPassword) : IRequest<Result<string>>;
