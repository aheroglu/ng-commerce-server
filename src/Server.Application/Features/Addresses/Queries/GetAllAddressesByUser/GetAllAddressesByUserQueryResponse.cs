using Server.Application.Dtos;

namespace Server.Application.Features.Addresses.Queries.GetAllAddressesByUser;

public sealed record GetAllAddressesByUserQueryResponse(
    string Id,
    string AppUserId,
    AppUserDto AppUser,
    string Street,
    string City,
    string District,
    string PostalCode,
    string FullAddress,
    string AddressType,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
