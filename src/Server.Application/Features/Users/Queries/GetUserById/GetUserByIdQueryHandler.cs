using Mapster;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Server.Application.Common;
using Server.Domain.Entities;

namespace Server.Application.Features.Users.Queries.GetUserById;

internal sealed class GetUserByIdQueryHandler(
    UserManager<AppUser> userManager) : IRequestHandler<GetUserByIdQuery, Result<GetUserByIdQueryResponse>>
{
    public async Task<Result<GetUserByIdQueryResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        AppUser? user = await userManager
            .Users
            .FirstOrDefaultAsync(p => p.Id == request.AppUserId, cancellationToken);

        if (user is null) return Result<GetUserByIdQueryResponse>
                .Failure("User not found!");

        return Result<GetUserByIdQueryResponse>
            .Success(user.Adapt<GetUserByIdQueryResponse>());
    }
}
