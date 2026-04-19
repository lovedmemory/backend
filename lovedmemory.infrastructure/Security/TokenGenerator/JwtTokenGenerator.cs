using lovedmemory.domain.Entities;
using lovedmemory.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace lovedmemory.Infrastructure.Security.TokenGenerator;

public class JwtTokenGenerator(IOptions<JwtSettings> jwtSettings, AppDbContext dbContext) : IJwtTokenGenerator
{
    private readonly JwtSettings _jwtSettings = jwtSettings.Value;

    public async Task<string> GenerateTokenAsync(AppUser user, IEnumerable<string> userRoles)
    {
        // 1. Fix: Use HmacSha256 for Symmetric keys (SecurityAlgorithms.RsaSha256 is for certificates)
        SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(_jwtSettings.Secret));
        SigningCredentials credentials = new(key, SecurityAlgorithms.HmacSha256);

        // 2. Performance: Use Async and select only the Name string to reduce memory allocation
        List<string> permissions = await dbContext.UserRoles
            .Where(ur => ur.UserId == user.Id)
            .SelectMany(ur => dbContext.RolePermissions
                .Where(rp => rp.RoleId == ur.RoleId)
                .Select(rp => rp.Permission.Name))
            .Distinct()
            .ToListAsync();

        List<Claim> claims =
        [
            new(JwtRegisteredClaimNames.Sub, user.Id),
            new(JwtRegisteredClaimNames.Email, user.Email!),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(JwtRegisteredClaimNames.Iss, _jwtSettings.Issuer),
            new(JwtRegisteredClaimNames.Aud, _jwtSettings.Audience),
            .. userRoles.Select(role => new Claim(ClaimTypes.Role, role)),

            .. permissions.Select(p => new Claim("permission", p)),
        ];

        SecurityTokenDescriptor tokenDescriptor = new()
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.TokenExpirationInMinutes),
            SigningCredentials = credentials,
            Issuer = _jwtSettings.Issuer,
            Audience = _jwtSettings.Audience
        };

        JwtSecurityTokenHandler tokenHandler = new();
        SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}