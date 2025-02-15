using System.Reflection;
using FluentValidation;
using lovedmemory.application.Contracts;
using lovedmemory.application.Services;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        //services.AddAutoMapper(Assembly.GetExecutingAssembly());
        // services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddScoped<IUserProvider, UserProvider>();

        services.AddScoped<IMemorialService, MemorialService>();
        services.AddScoped<ICommentService, CommentService>();
        services.AddScoped<IContactMessageService, ContactMessageservice>();
        return services;
    }
}
