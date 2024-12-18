using MediatR;
using Server.Application.Common;

namespace Server.Application.Features.Users.Commands.DeleteUser;

public sealed record DeleteUserCommand(
    string Email) : IRequest<Result<DeleteUserCommandResponse>>;
