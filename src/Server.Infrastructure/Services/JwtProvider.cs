﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Server.Application.Services;
using Server.Domain.Entities;
using Server.Infrastructure.Options.Jwt;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Server.Infrastructure.Services;

public sealed class JwtProvider(
    IOptions<JwtOptions> options,
    UserManager<AppUser> userManager) : IJwtProvider
{
    public async Task<string> GenerateToken(AppUser user)
    {
        var role = await userManager
            .GetRolesAsync(user);

        List<Claim> claims = new()
        {
            new Claim("Id", user.Id),
            new Claim("UserName", user.UserName ?? default!),
            new Claim("FullName", user.FullName ?? default!),
            new Claim("Email", user.Email ?? default!),
            new Claim("Role", role[0])
        };

        DateTime notBefore = DateTime.Now;
        DateTime expires = DateTime.Now.AddDays(15);

        SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(options.Value.SecretKey));
        SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha512);

        JwtSecurityToken securityToken = new(
            issuer: options.Value.Issuer,
            audience: options.Value.Audience,
            claims: claims,
            notBefore: notBefore,
            expires: expires,
            signingCredentials: signingCredentials);

        JwtSecurityTokenHandler handler = new();

        string token = handler.WriteToken(securityToken);

        return token;
    }
}
