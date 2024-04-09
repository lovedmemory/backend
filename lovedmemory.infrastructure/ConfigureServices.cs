using AutoMapper;
using lovedmemory.application.Common.Interfaces;
using lovedmemory.application.DTOs;
using lovedmemory.Application.Common.Interfaces;
using lovedmemory.Domain.Entities;
using lovedmemory.infrastructure.Security.Auth;
using lovedmemory.infrastructure.Security.RoleService;
using lovedmemory.infrastructure.Security.TokenGenerator;
using lovedmemory.infrastructure.Security.TokenValidation;
using lovedmemory.Infrastructure.Data;
using lovedmemory.Infrastructure.Identity;
using lovedmemory.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace schoolapp.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        try
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
            //Guard.Against.Null(connectionString, message: "Connection string 'DefaultConnection' not found.");

            //services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();


            services.AddDbContext<AppDbContext>((sp, options) =>
            {
                options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
                options.UseNpgsql(connectionString);

                //#if (UseSQLite)
                //            options.UseSqlite(connectionString);
                //#else
                //                options.UseSqlServer(connectionString);
                //#endif
            });

            services.AddScoped<IAppDbContext, AppDbContext>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services
                .ConfigureOptions<JwtBearerTokenValidationConfiguration>()
                .AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Tribute, TributeDto>());

            //services.AddScoped<ApplicationDbContextInitialiser>();

#if (UseApiOnly)
        services.AddAuthentication()
            .AddBearerToken(IdentityConstants.BearerScheme);

        services.AddAuthorizationBuilder();

        services
            .AddIdentityCore<ApplicationUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddApiEndpoints();
#else
            services
                .AddDefaultIdentity<AppUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();
#endif
            services.AddScoped<UserManager<AppUser>>();
            services.AddTransient<IIdentityService, IdentityService>();

            services.AddScoped<IRoleService,  RoleService>();
            //services.AddScoped<RoleManager<IdentityRole>>();

            services.AddSingleton<IDateTime, DateTimeService>();

            //services.AddAuthorization(options =>
            //    options.AddPolicy(Policies.CanPurge, policy => policy.RequireRole(Roles.Administrator)));

        }
        catch (Exception ex)
        {

            Console.WriteLine($"Error during migration: {ex.Message}");
            throw;
        }
        return services;
    }
}