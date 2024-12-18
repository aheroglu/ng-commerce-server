using Mapster;
using MediatR;
using Server.Application.Common;
using Server.Domain.Entities;
using Server.Domain.Repositories;

namespace Server.Application.Features.Addresses.Commands.DeleteAddress;

public sealed class DeleteAddressCommandHandler(
    IQueryRepository<Address> queryRepository,
    ICommandRepository<Address> commandRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteAddressCommand, Result<DeleteAddressCommandResponse>>
{
    public async Task<Result<DeleteAddressCommandResponse>> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
    {
        Address address = await queryRepository
            .GetByAsync(p => p.Id == request.Id, cancellationToken);

        if (address is null) return Result<DeleteAddressCommandResponse>
                .Failure("Address not found!");

        commandRepository
            .Delete(address);

        await unitOfWork
            .SaveChangesAsync(cancellationToken);

        return Result<DeleteAddressCommandResponse>.Success(
            "Address was successfully deleted",
            address.Adapt<DeleteAddressCommandResponse>());
    }
}
