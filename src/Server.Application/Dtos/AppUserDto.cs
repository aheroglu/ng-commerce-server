namespace Server.Application.Dtos;

public sealed record AppUserDto(
    string Id,
    string FullName,
    string UserName,
    string Email,
    string PhoneNumber,
    DateOnly BirthDate,
    bool IsBlocked);