using Duende.IdentityServer.Extensions;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace lovedmemory.infrastructure.Security.CurrentUserProvider
{
    public class UserProvider :IUserProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public CurrentUser GetCurrentUser()
        {
            if (_httpContextAccessor.HttpContext == null)
            {
                throw new Exception();
            }
            if (_httpContextAccessor.HttpContext.User?.IsAuthenticated()==false)
            {
                throw new Exception();
            }

            string id = GetSingleClaimValue(ClaimTypes.NameIdentifier);
            var permissions = GetClaimValues("permissions");
            var roles = GetClaimValues(ClaimTypes.Role);
            // var policies = GetClaimValues(ClaimTypes.)
            var firstName = GetSingleClaimValue(JwtRegisteredClaimNames.Name);
            
            var email = GetSingleClaimValue(ClaimTypes.Email);

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
