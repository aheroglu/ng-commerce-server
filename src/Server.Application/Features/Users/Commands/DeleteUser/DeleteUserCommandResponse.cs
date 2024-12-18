namespace Server.Application.Features.Users.Commands.DeleteUser;

public sealed record DeleteUserCommandResponse(
    string Id,
    string UserName,
    string Email);
