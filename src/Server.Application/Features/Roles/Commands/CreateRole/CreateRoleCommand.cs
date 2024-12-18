using MediatR;
using Server.Application.Common;

namespace Server.Application.Features.Roles.Commands.CreateRole;

public sealed record CreateRoleCommand(
    string Name) : IRequest<Result<CreateRoleCommandResponse>>;
