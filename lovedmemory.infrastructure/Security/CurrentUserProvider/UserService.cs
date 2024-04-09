using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using lovedmemory.Infrastructure.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace lovedmemory.infrastructure.Security.CurrentUserProvider;

public class UserService : IUserService
{
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly UserManager<AppUser> _userManager;
    public UserService(RoleManager<IdentityRole> roleManager, IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager)
    {
        _roleManager = roleManager;
        _httpContextAccessor = httpContextAccessor;
        _userManager = userManager;
    }

    // Methods to manage roles
    public async Task<bool> CreateRoleAsync(string roleName)
    {
        var roleExists = await _roleManager.RoleExistsAsync(roleName);
        if (roleExists)
            return false;

        var result = await _roleManager.CreateAsync(new IdentityRole(roleName));
        return result.Succeeded;
    }

    public async Task<IEnumerable<string>> GetUserRolesAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
            return Enumerable.Empty<string>();

        var userRoles = await _userManager.GetRolesAsync(user);
        return userRoles;
    }
    public async Task<bool> AssignRoleToUserAsync(string userId, string roleName)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
            return false;

        var role = await _roleManager.FindByNameAsync(roleName);
        if (role == null)
            return false;

        var result = await _userManager.AddToRoleAsync(user, roleName);
        return result.Succeeded;
    }
    public async Task<IEnumerable<string>> GetRolesAsync()
    {
        return await _roleManager.Roles.Select(r => r.Name).ToListAsync();
    }
    public CurrentUser GetCurrentUser()
    {
        if (_httpContextAccessor.HttpContext == null)
        {
            throw new Exception();
        }

        var id = GetSingleClaimValue("id");
        //var id = Guid.Parse(GetSingleClaimValue("id"));

        var permissions = GetClaimValues("permissions");
        var roles = GetClaimValues(ClaimTypes.Role);
       // var policies = GetClaimValues(ClaimTypes.)
        var firstName = GetSingleClaimValue(JwtRegisteredClaimNames.Name);
        var lastName = GetSingleClaimValue(ClaimTypes.Surname);
        var email = GetSingleClaimValue(ClaimTypes.Email);

        return new CurrentUser(id, firstName, lastName, email, permissions, roles);
    }

    private List<string> GetClaimValues(string claimType) =>
        _httpContextAccessor.HttpContext!.User.Claims
            .Where(claim => claim.Type == claimType)
            .Select(claim => claim.Value)
            .ToList();

    private string GetSingleClaimValue(string claimType) =>
        _httpContextAccessor.HttpContext!.User.Claims
            .Single(claim => claim.Type == claimType)
            .Value;
}