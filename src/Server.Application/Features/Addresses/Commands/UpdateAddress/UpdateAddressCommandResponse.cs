namespace Server.Application.Features.Addresses.Commands.UpdateAddress;

public sealed record UpdateAddressCommandResponse(
    string Id,
    string Street,
    string City,
    string PostalCode,
    string Country,
    string AddressType,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
