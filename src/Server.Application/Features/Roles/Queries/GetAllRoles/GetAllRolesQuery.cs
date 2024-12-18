using MediatR;
using Server.Application.Common;

namespace Server.Application.Features.Roles.Queries.GetAllRoles;

public sealed record GetAllRolesQuery : IRequest<Result<List<GetAllRolesQueryResponse>>>;
