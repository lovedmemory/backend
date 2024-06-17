using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using lovedmemory.application.Common.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace lovedmemory.infrastructure.Security.TokenGenerator;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly JwtSettings _jwtSettings;

    public JwtTokenGenerator(IOptions<JwtSettings> jwtSettings)
    {
        _jwtSettings = jwtSettings.Value;
    }

    public string GenerateToken(
        string id,
        string firstName,
        string lastName,
        string email
        //List<string?> permissions,
        //List<string?> roles
        )
    {

       var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Name, $"{lastName} ${firstName}"),//user name
            new(JwtRegisteredClaimNames.Email, email),
            new(JwtRegisteredClaimNames.NameId, id),
            //new(ClaimTypes.NameIdentifier,id ),
        };

        //roles.ForEach(role => claims.Add(new(ClaimTypes.Role, role)));
        //permissions.ForEach(permission => claims.Add(new("permissions", permission)));

        var token = new JwtSecurityToken(
             _jwtSettings.Issuer,
             _jwtSettings.Audience,
            claims,
            expires: DateTime.Now.AddMinutes(60),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}