using lovedmemory.application.Common.Interfaces;
using lovedmemory.application.DTOs;
using lovedmemory.Domain.Entities.Other;
using lovedmemory.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace lovedmemory.infrastructure.Security.RoleService
{
    public class PermissionService : IPermissionService
    {
        private readonly AppDbContext _context;
        private readonly ILogger<PermissionService> _logger;
        public PermissionService(AppDbContext context, ILogger<PermissionService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<Permission>?> GetAllPermissions()
        {
            return _context.Permissions == null
                ? null
                : (IEnumerable<Permission>)await _context.Permissions

                .ToListAsync();
        }

        public async Task<Permission?> GetPermission(int id)
        {
            if (_context.Permissions == null)
            {
                return null;
            }
            Permission? permission = await _context.Permissions.Where(t => t.Id == id)


                .FirstOrDefaultAsync();


            return permission;
        }

        public async Task<Permission?> PutPermission(int id, Permission permission, CancellationToken cancellationToken)
        {
            if (permission == null || id != permission.Id)
            {
                return null;
            }

            try
            {
                Permission? existingPermission = await _context.Permissions.FindAsync([id], cancellationToken);

                if (existingPermission == null)
                {
                    return null; // Permission with the given ID not found.
                }

                _context.Permissions.Entry(existingPermission).CurrentValues.SetValues(permission);

                _ = await _context.SaveChangesAsync(cancellationToken);

                return existingPermission;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating permission");
                return null;
            }
        }

        public async Task<bool> PostPermission(PermissionDto permission, CancellationToken cancellationToken)
        {
            if (_context.Permissions == null)
            {
                return false;
            }
            Permission newPermission = new()
            {
                Name = permission.Name,
                Desc = permission.Desc
            };
            _ = _context.Permissions.Add(newPermission);
            _ = await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<bool> DeletePermission(int id, CancellationToken cancellationToken)
        {
            if (_context.Permissions == null)
            {
                return false;
            }
            Permission? Permission = await _context.Permissions.FindAsync(id);
            if (Permission == null)
            {
                return true;
            }

            _ = _context.Permissions.Remove(Permission);
            _ = await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

    }
}
