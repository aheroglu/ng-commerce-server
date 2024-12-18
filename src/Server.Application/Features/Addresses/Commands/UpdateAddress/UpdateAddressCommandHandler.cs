using Mapster;
using MapsterMapper;
using MediatR;
using Server.Application.Common;
using Server.Domain.Entities;
using Server.Domain.Repositories;

namespace Server.Application.Features.Addresses.Commands.UpdateAddress;

internal sealed class UpdateAddressCommandHandler(
    IQueryRepository<Address> queryRepository,
    ICommandRepository<Address> commandRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateAddressCommand, Result<UpdateAddressCommandResponse>>
{
    public async Task<Result<UpdateAddressCommandResponse>> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
    {
        Address address = await queryRepository
            .GetByAsync(p => p.Id == request.Id, cancellationToken);

        if (address is null) return Result<UpdateAddressCommandResponse>
                .Failure("Address not found!");

        mapper.Map(request, address);

        commandRepository
            .Update(address);

        await unitOfWork
            .SaveChangesAsync(cancellationToken);

        return Result<UpdateAddressCommandResponse>.Success(
            "Address was successfully updated",
            address.Adapt<UpdateAddressCommandResponse>());
    }
}
