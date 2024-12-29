using lovedmemory.application.DTOs;
using lovedmemory.Domain.Entities.Other;
namespace lovedmemory.application.Common.Interfaces
{
    public interface IPermissionService
    {
        Task<bool> DeletePermission(int id, CancellationToken cancellationToken);
        Task<Permission?> GetPermission(int id);
        Task<IEnumerable<Permission>> GetAllPermissions();
        Task<bool> PostPermission(PermissionDto permission, CancellationToken cancellationToken);
        Task<Permission?> PutPermission(int id, Permission permission, CancellationToken cancellationToken);

    }
}
