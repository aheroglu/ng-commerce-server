using Server.Domain.Entities;

namespace Server.Application.Services;

public interface IJwtProvider
{
    Task<string> GenerateToken(AppUser user);
}
