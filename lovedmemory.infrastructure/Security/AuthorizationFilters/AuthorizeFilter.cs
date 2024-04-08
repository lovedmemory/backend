using lovedmemory.application.Common.Security.Request;
using lovedmemory.infrastructure.Security.CurrentUserProvider;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace lovedmemory.infrastructure.Security.AuthorizationFilters
{
    public class AuthorizationFilter : IAuthorizationFilter
    {
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _context;

        public AuthorizationFilter(IUserService userService, IHttpContextAccessor httpContextAccessor)
        {
            _userService = userService;
            _context = httpContextAccessor;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            try { 
           
            // Get the authorize attribute from the controller or action
            var authorizeAttribute = context.ActionDescriptor.EndpointMetadata
                .OfType<AuthorizeAttribute>()
                .FirstOrDefault();

            if (authorizeAttribute == null)
            {
                // No authorization attribute found, allow access
                return;
            }

            // Check permissions
            if (!string.IsNullOrEmpty(authorizeAttribute.Permissions) && !HasPermission(authorizeAttribute.Permissions))
            {
                context.Result = new ForbidResult();
                return;
            }

            // Check roles
            if (!string.IsNullOrEmpty(authorizeAttribute.Roles) && !HasRole(authorizeAttribute.Roles))
            {
                context.Result = new ForbidResult();
                return;
            }

                // Check policies
                //if (!string.IsNullOrEmpty(authorizeAttribute.Policies) && !HasPolicy(authorizeAttribute.Policies))
                //{
                //    context.Result = new ForbidResult();
                //    return;
                //}
            }
            catch (Exception ex) {
                context.Result = new ForbidResult();
                return;
            }
        }

        // Implement methods to check permissions, roles, and policies
        private bool HasPermission(string permissions)
        {
            // Get the current user's identity
            var userId = _context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);

            //var userId = _context.HttpContext.User.Identity.GetUserId();

            // Get the user's permissions from the UserService
            var userPermissions = _userService.GetCurrentUser().Permissions;

            // Check if the user has the required permissions
            return permissions.Split(',')
                .All(permission => userPermissions.Contains(permission.Trim()));
        }

        private bool HasRole(string roles)
        {
            // Get the current user's identity
            var userId = _context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);

            // Get the user's roles from the UserService
            var userRoles = _userService.GetCurrentUser().Roles;

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
