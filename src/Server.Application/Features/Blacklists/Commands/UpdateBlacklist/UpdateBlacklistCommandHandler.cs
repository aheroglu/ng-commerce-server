using Mapster;
using MapsterMapper;
using MediatR;
using Server.Application.Common;
using Server.Domain.Entities;
using Server.Domain.Repositories;

namespace Server.Application.Features.Blacklists.Commands.UpdateBlacklist;

internal sealed class UpdateBlacklistCommandHandler(
    IQueryRepository<Blacklist> queryRepository,
    ICommandRepository<Blacklist> commandRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateBlacklistCommand, Result<UpdateBlacklistCommandResponse>>
{
    public async Task<Result<UpdateBlacklistCommandResponse>> Handle(UpdateBlacklistCommand request, CancellationToken cancellationToken)
    {
        Blacklist blacklist = await queryRepository
            .GetByAsync(p => p.Id == request.Id, cancellationToken);

        if (blacklist is null) return Result<UpdateBlacklistCommandResponse>
                .Failure("Blacklist record not found!");

        mapper.Map(request, blacklist);

        commandRepository
            .Update(blacklist);

        await unitOfWork
            .SaveChangesAsync(cancellationToken);

        return Result<UpdateBlacklistCommandResponse>
            .Success(
                "Blacklist record was successfully updated",
                blacklist.Adapt<UpdateBlacklistCommandResponse>());
    }
}
