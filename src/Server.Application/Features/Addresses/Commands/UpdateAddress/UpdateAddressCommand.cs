using MediatR;
using Server.Application.Common;

namespace Server.Application.Features.Addresses.Commands.UpdateAddress;

public sealed record UpdateAddressCommand(
    string Id,
    string AppUserId,
    string Street,
    string City,
    string District,
    string PostalCode,
    string FullAddress,
    string AddressType) : IRequest<Result<UpdateAddressCommandResponse>>;
