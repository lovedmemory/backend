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
        services.AddScoped<ITributeService, TributeService>();
        services.AddScoped<ICommentService, CommentService>();
        return services;
    }
}
