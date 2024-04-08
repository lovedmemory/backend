using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using lovedmemory.application.Common.Interfaces;
using lovedmemory.application.DTOs;
using lovedmemory.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace lovedmemory.infrastructure.Security.Auth;

public class AuthService : IAuthService
{
    private readonly IJwtTokenGenerator _tokenGenerator;
    private readonly UserManager<AppUser> _userManager;
    private readonly IConfiguration _configuration;

    public AuthService(UserManager<AppUser> userManager, IConfiguration configuration, IJwtTokenGenerator tokenGenerator)
    {
        _userManager = userManager;
        _configuration = configuration;
        _tokenGenerator = tokenGenerator;
    }

    public async Task<string> Register(RegisterDto request)
    {
        var userByEmail = await _userManager.FindByEmailAsync(request.Email);
        var userByUsername = await _userManager.FindByNameAsync(request.Username);
        if (userByEmail is not null || userByUsername is not null)
        {
            throw new ArgumentException($"User with email {request.Email} or username {request.Username} already exists.");
        }

        AppUser user = new()
        {
            Email = request.Email,
            UserName = request.Username,
            
            SecurityStamp = Guid.NewGuid().ToString()
        };

        var result = await _userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
        {
            throw new ArgumentException($"Unable to register user {request.Username} errors: {GetErrorsText(result.Errors)}");
        }

        return await Login(new LoginDto { Username = request.Email, Password = request.Password });
    }

    public async Task<string> Login(LoginDto request)
    {
        var user = await _userManager.FindByNameAsync(request.Username);

        if (user is null)
        {
            user = await _userManager.FindByEmailAsync(request.Username);
        }

        if (user is null || !await _userManager.CheckPasswordAsync(user, request.Password))
        {
            throw new ArgumentException($"Unable to authenticate user {request.Username}");
        }

        

        var token = await _tokenGenerator.GenerateToken(user.Id, user.UserName,"",user.Email);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private JwtSecurityToken GetToken(IEnumerable<Claim> authClaims)
    {
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

        var token = new JwtSecurityToken(
            issuer: _configuration["JWT:ValidIssuer"],
            audience: _configuration["JWT:ValidAudience"],
            expires: DateTime.Now.AddHours(3),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));

        return token;
    }

    private string GetErrorsText(IEnumerable<IdentityError> errors)
    {
        return string.Join(", ", errors.Select(error => error.Description).ToArray());
    }
}
