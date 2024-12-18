using Mapster;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Server.Application.Common;
using Server.Domain.Entities;
using Server.Domain.Repositories;

namespace Server.Application.Features.Blacklists.Commands.DeleteBlacklist;

internal sealed class DeleteBlacklistCommandHandler(
    IQueryRepository<Blacklist> queryRepository,
    ICommandRepository<Blacklist> commandRepository,
    UserManager<AppUser> userManager,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteBlacklistCommand, Result<DeleteBlacklistCommandResponse>>
{
    public async Task<Result<DeleteBlacklistCommandResponse>> Handle(DeleteBlacklistCommand request, CancellationToken cancellationToken)
    {
        var blacklist = await queryRepository
            .GetByAsync(p => p.Id == request.Id, cancellationToken);

        if (blacklist is null) return Result<DeleteBlacklistCommandResponse>
                .Failure("Blacklist record not found!");

        AppUser? user = await userManager
            .FindByIdAsync(blacklist.AppUserId);

        if (user is null) return Result<DeleteBlacklistCommandResponse>
                .Failure("User not found!");

        commandRepository
            .Delete(blacklist);

        user.IsBlocked = false;

        await userManager
            .UpdateAsync(user);

        await unitOfWork
            .SaveChangesAsync(cancellationToken);

        return Result<DeleteBlacklistCommandResponse>
            .Success(
                "User was successfully removed from blacklist",
                blacklist.Adapt<DeleteBlacklistCommandResponse>());
    }
}
