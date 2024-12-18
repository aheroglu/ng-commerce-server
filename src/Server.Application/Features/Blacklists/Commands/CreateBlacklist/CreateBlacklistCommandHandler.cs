using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Server.Application.Common;
using Server.Domain.Entities;
using Server.Domain.Repositories;

namespace Server.Application.Features.Blacklists.Commands.CreateBlacklist;

internal sealed class CreateBlacklistCommandHandler(
    IBlacklistQueryRepository queryRepository,
    IBlacklistCommandRepository commandRepository,
    UserManager<AppUser> userManager,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<CreateBlacklistCommand, Result<CreateBlacklistCommandResponse>>
{
    public async Task<Result<CreateBlacklistCommandResponse>> Handle(CreateBlacklistCommand request, CancellationToken cancellationToken)
    {
        AppUser? user = await userManager
           .FindByIdAsync(request.AppUserId);

        if (user is null) return Result<CreateBlacklistCommandResponse>
                .Failure("User not found!");

        bool isUserExists = await queryRepository
            .IsUserExistsAsync(request.AppUserId, cancellationToken);

        if (isUserExists) return Result<CreateBlacklistCommandResponse>
                .Failure("User already exists!");

        Blacklist blacklist = mapper.Map<Blacklist>(request);

        await commandRepository
            .CreateAsync(blacklist, cancellationToken);

        user.IsBlocked = true;

        await userManager
            .UpdateAsync(user);

        await unitOfWork
            .SaveChangesAsync(cancellationToken);

        return Result<CreateBlacklistCommandResponse>
            .Success(
                "User was successfully added to blacklist",
                blacklist.Adapt<CreateBlacklistCommandResponse>());
    }
}
