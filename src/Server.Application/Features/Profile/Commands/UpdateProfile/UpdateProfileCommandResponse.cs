namespace Server.Application.Features.Profile.Commands.UpdateProfile;

public sealed record UpdateProfileCommandResponse(
    string Id,
    string FullName,
    string Email,
    DateTime BirthDate,
    string PhoneNumber);
