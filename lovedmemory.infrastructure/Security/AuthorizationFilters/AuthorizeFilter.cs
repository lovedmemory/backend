using lovedmemory.application.Common.Security.Request;
using lovedmemory.infrastructure.Security.CurrentUserProvider;
using lovedmemory.infrastructure.Security.RoleService;
using lovedmemory.infrastructure.Security.TokenGenerator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace lovedmemory.infrastructure.Security.AuthorizationFilters
{
    public class AuthorizationFilter : IAuthorizationFilter
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;

        private readonly IHttpContextAccessor _context;
        private readonly JwtSettings _jwtSettings;
        public AuthorizationFilter(IUserService userService, IHttpContextAccessor httpContextAccessor, IOptions<JwtSettings> jwtSettings, IRoleService roleService)
        {
            _userService = userService;
            _context = httpContextAccessor;
            _jwtSettings = jwtSettings.Value;
            _roleService = roleService;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var authorizeAttribute = context.ActionDescriptor.EndpointMetadata
                     .OfType<AuthorizeAttribute>()
                     .FirstOrDefault();

            if (authorizeAttribute == null)
            {
                // No authorization attribute found, allow access
                return;
            }
            string token = GetTokenFromRequest(context.HttpContext.Request);
          
            if (!string.IsNullOrEmpty(token))
            {
                try
                {
                    var principal = GetPrincipalFromToken(token);
                    context.HttpContext.User = principal;
                    var userId = _context.HttpContext.User.FindFirst(c => c.Type == "id")?.Value;
                    // Get the authorize attribute from the controller or action


                    // Check permissions
                    if (!string.IsNullOrEmpty(authorizeAttribute.Permissions) && !HasPermission(userId, authorizeAttribute.Permissions))
                    {
                        context.Result = new UnauthorizedResult();
                        return;
                    }

                    // Check roles
                    if (!string.IsNullOrEmpty(authorizeAttribute.Roles) && !HasRole(userId, authorizeAttribute.Roles))
                    {
                        context.Result = new UnauthorizedResult();
                        return;
                    }


                    // Check policies
                    //if (!string.IsNullOrEmpty(authorizeAttribute.Policies) && !HasPolicy(authorizeAttribute.Policies))
                    //{
                    //    context.Result = new ForbidResult();
                    //    return;
                    //}
                }
                catch (Exception ex)
                {
                    context.Result = new UnauthorizedResult();
                    return;
                }
            }
            else
            {
                context.Result = new UnauthorizedResult();
                return;
            }
        }

        private string GetTokenFromRequest(HttpRequest request)
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
        private ClaimsPrincipal GetPrincipalFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = _jwtSettings.Issuer,
                ValidateAudience = true,
                ValidAudience = _jwtSettings.Audience,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
                ClockSkew = TimeSpan.Zero
            };

            try
            {
                var principal = tokenHandler.ValidateToken(token, validationParameters, out var securityToken);
                return principal;
            }
            catch (SecurityTokenException)
            {
                // Token validation failed
                return null;
            }
        }
        // Implement methods to check permissions, roles, and policies
        private bool HasPermission(string userId, string permissions)
        {
            // Get the current user's identity
            var userRoles = _roleService.GetUserRolesAsync(userId);

            // Get the user's permissions from the UserService
            var userPermissions = _userService.GetCurrentUser().Permissions;

            // Check if the user has the required permissions
            return permissions.Split(',')
                .All(permission => userPermissions.Contains(permission.Trim()));
        }

        private bool HasRole(string userId, string roles)
        {
            // Get the user's roles from the UserService
            var userRoles = _roleService.GetUserRolesAsync(userId).Result;

           // Check if the user belongs to any of the required roles
            return roles.Split(',')
                .Any(role => userRoles.Contains(role.Trim()));
        }

        //private bool HasPolicy(string policies)
        //{
        //    // Get the current user's identity
        //    var userId = _context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);

        //    //var userId = _context.HttpContext.User.Identity.GetUserId();

        //    // Get the user's policies from the UserService
        //    var userPolicies = _userService.GetCurrentUser().Po;

        //    // Check if the user has any of the required policies
        //    return policies.Split(',')
        //        .Any(policy => userPolicies.Contains(policy.Trim()));
        //}
    }
}
