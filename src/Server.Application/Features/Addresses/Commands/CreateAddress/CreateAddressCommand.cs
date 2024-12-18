using MediatR;
using Server.Application.Common;

namespace Server.Application.Features.Addresses.Commands.CreateAddress;

public sealed record CreateAddressCommand(
    string AppUserId,
    string Street,
    string City,
    string District,
    string PostalCode,
    string FullAddress,
    string AddressType) : IRequest<Result<CreateAddressCommandResponse>>;
