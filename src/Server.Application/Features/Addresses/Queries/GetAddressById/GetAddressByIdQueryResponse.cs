using Server.Application.Dtos;

namespace Server.Application.Features.Addresses.Queries.GetAddressById;

public sealed record GetAddressByIdQueryResponse(
    string Id,
    string AppUserId,
    AppUserDto AppUser,
    string Street,
    string City,
    string PostalCode,
    string Country,
    string AddressType,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
