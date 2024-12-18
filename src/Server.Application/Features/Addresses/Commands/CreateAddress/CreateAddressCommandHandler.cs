using Mapster;
using MapsterMapper;
using MediatR;
using Server.Application.Common;
using Server.Domain.Entities;
using Server.Domain.Repositories;

namespace Server.Application.Features.Addresses.Commands.CreateAddress;

internal sealed class CreateAddressCommandHandler(
    ICommandRepository<Address> commandRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<CreateAddressCommand, Result<CreateAddressCommandResponse>>
{
    public async Task<Result<CreateAddressCommandResponse>> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
    {
        Address address = mapper.Map<Address>(request);

        await commandRepository
            .CreateAsync(address, cancellationToken);

        await unitOfWork
            .SaveChangesAsync(cancellationToken);

        return Result<CreateAddressCommandResponse>.Success(
            "Address was successfully created",
            address.Adapt<CreateAddressCommandResponse>());
    }
}