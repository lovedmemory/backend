using lovedmemory.application.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.JsonWebTokens;
using System.Security.Claims;

namespace lovedmemory.application.Services
{
    public class UserProvider : IUserProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public CurrentUser GetCurrentUser()
        {
            var user = _httpContextAccessor.HttpContext.User;

            if (_httpContextAccessor.HttpContext == null)
            {
                throw new Exception();
            }
            if (user?.Identity == null || !user.Identity.IsAuthenticated)
            {
                throw new Exception("User is not authenticated.");
            }
            if (_httpContextAccessor.HttpContext.User?.Identity.IsAuthenticated == false)
            {
                throw new Exception();
            }
            var _claims = _httpContextAccessor.HttpContext!.User.Claims;
            string id = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var permissions = GetClaimValues("permissions");
            var roles = GetClaimValues(ClaimTypes.Role);
            var firstName = "";

            var email = GetClaimValues(ClaimTypes.Email).FirstOrDefault();

            return new CurrentUser(id, firstName, "", email, permissions, roles);
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
}
