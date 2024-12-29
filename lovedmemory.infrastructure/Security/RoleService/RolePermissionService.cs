using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using lovedmemory.Domain.Entities.Other;
using lovedmemory.Infrastructure.Data;
using lovedmemory.application.DTOs;
using lovedmemory.application.Common.Interfaces;

public class RolePermissionService : IRolePermissionService
{
    private readonly AppDbContext _context;
    private readonly ILogger<RolePermissionService> _logger;

    public RolePermissionService(AppDbContext context, ILogger<RolePermissionService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public Task<bool> AssignRolePermissionToUserAsync(string userId, string rolepermissionName)
    {
        throw new NotImplementedException();
    }

    public async Task<RolePermission> CreateRolePermissionAsync(RolePermissionDto rolePermission)
    {
        try
        {

            var newRolePermission = new RolePermission
            {
                RoleId = rolePermission.RoleId,
                PermissionId = rolePermission.PermissionId
            };
            _context.RolePermissions.Add(newRolePermission);
            await _context.SaveChangesAsync();
            return newRolePermission;

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while creating role permission");
            throw;
        }
    }
    public async Task<bool> EditRolePermissionAsync(int id, RolePermissionDto rolePermission)
    {

        _context.Entry(rolePermission).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
            return true;
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!RolePermissionExists(id))
            {
                return true;
            }
            else
            {
                throw;
            }
        }
    }
    public async Task<List<RolePermissionDto>> GetRolePermissions()
    {
        var result = await (from rp in _context.RolePermissions
                            join r in _context.Roles on rp.RoleId equals r.Id
                            join p in _context.Permissions on rp.PermissionId equals p.Id
                            select new RolePermissionDto
                            {
                                Id = rp.Id,
                                RoleId = rp.RoleId,
                                RoleName = r.Name,
                                PermissionId = rp.PermissionId,
                                PermissionName = p.Name,
                                PermissionDesc = p.Desc
                            }).ToListAsync();

        return result;
    }
    public async Task<bool> DeleteRolePermissionAsync(int id)
    {
        try
        {
            var rolePermission = await _context.RolePermissions.FindAsync(id);
            if (rolePermission == null)
            {
                return false;
            }

            _context.RolePermissions.Remove(rolePermission);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    private bool RolePermissionExists(int id)
    {
        return _context.RolePermissions.Any(e => e.Id == id);
    }
}
