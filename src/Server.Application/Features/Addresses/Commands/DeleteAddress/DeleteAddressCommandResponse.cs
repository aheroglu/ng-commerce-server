namespace Server.Application.Features.Addresses.Commands.DeleteAddress;

public sealed record DeleteAddressCommandResponse(
    string Id,
    string Street,
    string City,
    string PostalCode,
    string Country,
    string AddressType,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
