
using Microsoft.AspNetCore.Identity;

namespace lovedmemory.infrastructure.Security.RoleService
{
    public interface IRoleService
    {
        Task<bool> AssignRoleToUserAsync(string userId, string roleName);
        Task<bool> CreateRoleAsync(string roleName);
        List<IdentityRole> GetRoles();
        Task<IEnumerable<string>> GetUserRolesAsync(string userId);
    }
}
