namespace Server.Application.Features.Addresses.Commands.CreateAddress;

public sealed record CreateAddressCommandResponse(
    string Id,
    string Street,
    string City,
    string PostalCode,
    string Country,
    string AddressType,
    DateTime CreatedAt);