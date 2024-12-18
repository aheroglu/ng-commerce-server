using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Server.Application.Common;
using Server.Domain.Entities;

namespace Server.Application.Features.Roles.Queries.GetAllRoles;

internal sealed class GetAllRolesQueryHandler(
    RoleManager<AppRole> roleManager,
    IMapper mapper) : IRequestHandler<GetAllRolesQuery, Result<List<GetAllRolesQueryResponse>>>
{
    public async Task<Result<List<GetAllRolesQueryResponse>>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
    {
        var roles = mapper
            .Map<List<GetAllRolesQueryResponse>>(await roleManager
            .Roles
            .ToListAsync(cancellationToken));

        return Result<List<GetAllRolesQueryResponse>>
            .Success(roles);
    }
}
