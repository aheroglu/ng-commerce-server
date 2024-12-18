using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Server.Application.Common;
using Server.Domain.Entities;

namespace Server.Application.Features.Users.Queries.GetAllUsers;

public sealed class GetAllUsersQueryHandler(
    UserManager<AppUser> userManager) : IRequestHandler<GetAllUsersQuery, Result<List<GetAllUsersQueryResponse>>>
{
    public async Task<Result<List<GetAllUsersQueryResponse>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        List<GetAllUsersQueryResponse> response = new();

        var users = await userManager
            .Users
            .ToListAsync(cancellationToken);


        foreach (var user in users)
        {
            var roles = await userManager
                .GetRolesAsync(user);

            var role = roles.FirstOrDefault();

            var result = new GetAllUsersQueryResponse(
                user.Id,
                user.FullName,
                user.Email!,
                role!,
                user.IsBlocked);

            response.Add(result);
        }

        return Result<List<GetAllUsersQueryResponse>>
            .Success(response);
    }
}