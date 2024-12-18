namespace Server.Application.Dtos;

public sealed record AddressDto(
    string AppUserId,
    AppUserDto AppUser,
    string Street,
    string City,
    string District,
    string PostalCode,
    string FullAddress,
    string AddressType);