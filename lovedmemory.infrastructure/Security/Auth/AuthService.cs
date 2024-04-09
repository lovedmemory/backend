using lovedmemory.application.Common.Interfaces;
using lovedmemory.application.DTOs;
using lovedmemory.infrastructure.Identity;
using lovedmemory.infrastructure.Security.TokenGenerator;
using lovedmemory.Infrastructure.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace lovedmemory.infrastructure.Security.Auth;

public class AuthService : IAuthService
{
    private readonly IJwtTokenGenerator _tokenGenerator;
    private readonly UserManager<AppUser> _userManager;

    public AuthService(UserManager<AppUser> userManager,  IJwtTokenGenerator tokenGenerator)
    {
        _userManager = userManager;
        _tokenGenerator = tokenGenerator;
    }

    public async Task<string> Register(RegisterDto request)
    {
        var userByEmail = await _userManager.FindByEmailAsync(request.Email);
        //var userByUsername = await _userManager.FindByNameAsync(request.Username);
        if (userByEmail is not null )
        {
            throw new ArgumentException($"User with email {request.Email} already exists.");
        }

        AppUser user = new()
        {
            Email = request.Email,
            UserName = request.Email,
            FirstName = request.Firstname,
            LastName = request.Lastname,
            OtherName = request.Othername,

            SecurityStamp = Guid.NewGuid().ToString()
        };

        var result = await _userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
        {
            throw new ArgumentException($"Unable to register user {string.Concat(request.Firstname, " ", request.Lastname)} errors: {GetErrorsText(result.Errors)}");
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

        var token =  _tokenGenerator.GenerateToken(user.Id, user.FirstName,user.LastName,user.Email);

        return token;
    }

    public string GetTokenFromRequest(HttpRequest request)
    {
        string token = null;

        // Get the Authorization header from the request
        var authHeader = request.Headers["Authorization"];

        if (authHeader.Count > 0)
        {
            // Extract the token from the Authorization header (e.g., Bearer <token>)
            var authValue = authHeader.ToString().Split(' ');
            if (authValue.Length == 2 && authValue[0].Equals("Bearer", StringComparison.OrdinalIgnoreCase))
            {
                token = authValue[1];
            }
        }

        return token;
    }

    private string GetErrorsText(IEnumerable<IdentityError> errors)
    {
        return string.Join(", ", errors.Select(error => error.Description).ToArray());
    }
}
