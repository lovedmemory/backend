using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using lovedmemory.Infrastructure.Security.Auth;
using lovedmemory.Infrastructure.Security.CurrentUserProvider;
using lovedmemory.Infrastructure.Security.RoleService;
using lovedmemory.Infrastructure.Security.TokenGenerator;
using lovedmemory.Infrastructure.Security.TokenValidation;
using lovedmemory.Infrastructure.Data;
using lovedmemory.Infrastructure.Persistence.Interceptors;
using lovedmemory.application.Common.Interfaces;
using lovedmemory.domain.Entities;


namespace lovedmemory.Infrastructure;

public static class DependencyInjection
{

    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {

        services

            .AddAuthentication(configuration)
            .AddAuthorization()
                       .AddHttpContextAccessor()

            .AddPersistence(configuration);
        return services;
    }




   

    private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<AppDbContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
            options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention();
        });
        services.AddScoped<IAppDbContext, AppDbContext>();

        return services;
    }

    public static IServiceCollection Authorization(this IServiceCollection services)
    {
        services.AddAuthorization(options =>
        {
            // Create a scope to access scoped services during configuration
            using var scope = services.BuildServiceProvider().CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            // Get permissions from DB
            var permissions = dbContext.Permissions
                .Select(p => p.Name)
                .ToList();

            // Register each permission as a policy
            foreach (var permission in permissions)
            {
                options.AddPolicy(permission,
                    policy => policy.Requirements.Add(new PermissionRequirement(permission)));
            }
        });

        // Register required services
        services.AddScoped<IAuthorizationHandler, PermissionHandler>();
        services.AddScoped<IUserProvider, UserProvider>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IRolePermissionService, RolePermissionService>();

        return services;
    }
    private static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.Section));
        services.AddScoped<IAuthService, AuthService>();

        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
        services
            .AddDefaultIdentity<AppUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>();

        services
            .Configure<IdentityOptions>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 6;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;
            })
            .ConfigureOptions<JwtBearerTokenValidationConfiguration>()
            .AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer();
        services.AddScoped<UserManager<AppUser>>();

        return services;
    }
}