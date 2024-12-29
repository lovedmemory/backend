using lovedmemory.application.DTOs;
using lovedmemory.Domain.Entities.Other;

namespace lovedmemory.application.Common.Interfaces
{
    public interface IRolePermissionService
    {
        Task<bool> AssignRolePermissionToUserAsync(string userId, string rolepermissionName);
        Task<RolePermission> CreateRolePermissionAsync(RolePermissionDto rolePermission);
        Task<bool> DeleteRolePermissionAsync(int id);
        Task<bool> EditRolePermissionAsync(int id, RolePermissionDto rolePermission);
        Task<List<RolePermissionDto>> GetRolePermissions();
    }
}
