using AutoMapper;
using lovedmemory.application.DTOs;
using lovedmemory.Application.Common.Interfaces;
using lovedmemory.Domain.Entities;
using lovedmemory.Infrastructure.Data;
using lovedmemory.Infrastructure.Identity;
using lovedmemory.Infrastructure.Services;
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

            services.AddSingleton<IDateTime, DateTimeService>();
            services.AddTransient<IIdentityService, IdentityService>();

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