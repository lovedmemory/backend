using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using lovedmemory.Infrastructure.Data;
using lovedmemory.domain.Entities;
using lovedmemory.Domain.Entities.Other;
using lovedmemory.application.Common.Security.Permissions;

namespace lovedmemory.Infrastructure.Persistence;

public class AppDbContextInitialiser
{
    private readonly ILogger<AppDbContextInitialiser> _logger;
    private readonly AppDbContext _context;
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AppDbContextInitialiser(ILogger<AppDbContextInitialiser> logger, AppDbContext context, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _logger = logger;
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            if (_context.Database.IsSqlServer())
            {
                await _context.Database.MigrateAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        // Seed Permissions
        await SeedPermissionsAsync();

        // Seed Roles with their permissions
        await SeedRolesAsync();

        // Seed Default Users
        await SeedUsersAsync();

        // Additional seeding if necessary
    }

    private async Task SeedPermissionsAsync()
    {
        var allPermissions = new List<(string Name, string Description)>
        {
            // Memorial permissions
            (Permission.Memorial.View, "View memorials"),
            (Permission.Memorial.Create, "Create memorials"),
            (Permission.Memorial.Update, "Update memorials"),
            (Permission.Memorial.Delete, "Delete memorials"),
            (Permission.Memorial.Search, "Search memorials"),

            // Tribute permissions
            (Permission.Tribute.View, "View tributes"),
            (Permission.Tribute.Create, "Create tributes"),
            (Permission.Tribute.Update, "Update tributes"),
            (Permission.Tribute.Delete, "Delete tributes"),

            // Comment permissions
            (Permission.Comment.View, "View comments"),
            (Permission.Comment.Create, "Create comments"),
            (Permission.Comment.Update, "Update comments"),
            (Permission.Comment.Delete, "Delete comments"),

            // User permissions
            (Permission.User.View, "View users"),
            (Permission.User.Create, "Create users"),
            (Permission.User.Update, "Update users"),
            (Permission.User.Delete, "Delete users"),
            (Permission.User.AssignRole, "Assign roles to users"),

            // Role permissions
            (Permission.Role.View, "View roles"),
            (Permission.Role.Create, "Create roles"),
            (Permission.Role.Update, "Update roles"),
            (Permission.Role.Delete, "Delete roles"),
            (Permission.Role.AssignPermission, "Assign permissions to roles"),

            // Reminder permissions
            (Permission.Reminder.Set, "Set reminders"),
            (Permission.Reminder.Get, "Get reminders"),
            (Permission.Reminder.Dismiss, "Dismiss reminders"),
            (Permission.Reminder.Delete, "Delete reminders"),

            // Subscription permissions
            (Permission.Subscription.Create, "Create subscriptions"),
            (Permission.Subscription.Delete, "Delete subscriptions"),
            (Permission.Subscription.Get, "Get subscriptions")
        };

        foreach (var (name, description) in allPermissions)
        {
            if (!_context.Permissions.Any(p => p.Name == name))
            {
                _context.Permissions.Add(new Permission
                {
                    Name = name,
                    Desc = description
                });
            }
        }

        await _context.SaveChangesAsync();
    }

    private async Task SeedRolesAsync()
    {
        // Administrator role - has all permissions
        var administratorRole = new IdentityRole("Administrator");
        if (_roleManager.Roles.All(r => r.Name != administratorRole.Name))
        {
            await _roleManager.CreateAsync(administratorRole);
        }

        // User role - basic permissions
        var userRole = new IdentityRole("User");
        if (_roleManager.Roles.All(r => r.Name != userRole.Name))
        {
            await _roleManager.CreateAsync(userRole);
        }

        // Assign all permissions to Administrator
        var adminRole = await _roleManager.FindByNameAsync("Administrator");
        if (adminRole != null)
        {
            var allPermissionIds = _context.Permissions.Select(p => p.Id).ToList();
            foreach (var permissionId in allPermissionIds)
            {
                var exists = await _context.RolePermissions
                    .AnyAsync(rp => rp.RoleId == adminRole.Id && rp.PermissionId == permissionId);
                if (!exists)
                {
                    _context.RolePermissions.Add(new RolePermission
                    {
                        RoleId = adminRole.Id,
                        PermissionId = permissionId
                    });
                }
            }
        }

        // Assign basic permissions to User role: view memorials, search memorials, view tributes, create tributes, view comments, create comments, get subscription
        var userRoleEntity = await _roleManager.FindByNameAsync("User");
        if (userRoleEntity != null)
        {
            var basicPermissions = new[]
            {
                Permission.Memorial.View,
                Permission.Memorial.Search,
                Permission.Tribute.View,
                Permission.Tribute.Create,
                Permission.Comment.View,
                Permission.Comment.Create,
                Permission.Subscription.Get
            };

            foreach (var permName in basicPermissions)
            {
                var permission = await _context.Permissions.FirstOrDefaultAsync(p => p.Name == permName);
                if (permission != null)
                {
                    var exists = await _context.RolePermissions
                        .AnyAsync(rp => rp.RoleId == userRoleEntity.Id && rp.PermissionId == permission.Id);
                    if (!exists)
                    {
                        _context.RolePermissions.Add(new RolePermission
                        {
                            RoleId = userRoleEntity.Id,
                            PermissionId = permission.Id
                        });
                    }
                }
            }
        }

        await _context.SaveChangesAsync();
    }

    private async Task SeedUsersAsync()
    {
        // Default administrator user
        var administrator = new AppUser 
        { 
            UserName = "administrator@localhost", 
            Email = "administrator@localhost",
            EmailConfirmed = true,
            FirstName = "System",
            LastName = "Administrator"
        };

        if (_userManager.Users.All(u => u.UserName != administrator.UserName))
        {
            await _userManager.CreateAsync(administrator, "Administrator1!");
            var adminRole = await _roleManager.FindByNameAsync("Administrator");
            if (adminRole != null)
            {
                await _userManager.AddToRoleAsync(administrator, adminRole.Name!);
            }
        }

        // Default regular user
        var regularUser = new AppUser
        {
            UserName = "user@localhost",
            Email = "user@localhost",
            EmailConfirmed = true,
            FirstName = "Regular",
            LastName = "User"
        };

        if (_userManager.Users.All(u => u.UserName != regularUser.UserName))
        {
            await _userManager.CreateAsync(regularUser, "User1!");
            var userRole = await _roleManager.FindByNameAsync("User");
            if (userRole != null)
            {
                await _userManager.AddToRoleAsync(regularUser, userRole.Name!);
            }
        }
    }
}
