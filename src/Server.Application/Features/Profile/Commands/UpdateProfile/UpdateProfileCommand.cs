using MediatR;
using Server.Application.Common;

namespace Server.Application.Features.Profile.Commands.UpdateProfile;

public sealed record UpdateProfileCommand(
    string Id,
    string FullName,
    string Email,
    DateTime BirthDate,
    string PhoneNumber) : IRequest<Result<UpdateProfileCommandResponse>>;