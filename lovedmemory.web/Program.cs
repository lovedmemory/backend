using lovedmemory.web.Services;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Events;
using lovedmemory.Infrastructure.Security.CurrentUserProvider;
using lovedmemory.Infrastructure;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
Console.WriteLine($"Application started on : { builder.WebHost.GetSetting("urls")}");
Log.Logger = new LoggerConfiguration()
    //.Enrich.With
    .Enrich.FromLogContext() //logging from DiagnosticContext
    .Enrich.WithProperty("ApplicationName", "lovedmemory_api")
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .WriteTo.Seq("http://localhost:5341")
    .WriteTo.File($"{builder.Environment.ContentRootPath}/Logs/webapi_.txt",
    LogEventLevel.Information,
    "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}{NewLine}",
    rollingInterval: RollingInterval.Day)
    .CreateLogger();
builder.Configuration.AddJsonFile("appsettings.json", false, true);
builder.Configuration.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: false, reloadOnChange: true);
builder.Configuration.AddEnvironmentVariables();
builder.Services.AddHealthChecks();
if (builder.Environment.IsProduction())
{
    builder.Services.AddHealthChecks();
    //builder.WebHost.UseUrls("http://0.0.0.0:5000");
}

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 4;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;
});
builder.Services.AddHttpContextAccessor();

// Add services to the container.
//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    //opt.SwaggerDoc("v1", new OpenApiInfo { Title = "My Api", Version = "v1" });
    opt.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Scheme = "bearer"
    });
    opt.OperationFilter<AuthenticationRequirementsOperationFilter>();
});

//builder.Services.AddAuthorization(options =>
//{
//    options.FallbackPolicy = new AuthorizationPolicyBuilder()
//        .RequireAuthenticatedUser()
//        .Build();
//});
builder.Logging.AddSerilog();

var app = builder.Build();
app.MapHealthChecks("/gesundheit");
// Configure the HTTP request pipeline.
app.UseCors(options => options
       .WithOrigins("http://localhost:3000")
       .AllowAnyHeader()
       .AllowAnyMethod()
       .SetIsOriginAllowed(hostName => true)
       .AllowCredentials()
       .SetPreflightMaxAge(TimeSpan.FromSeconds(86400))
   );
app.UseSwagger();
app.UseSwaggerUI();

//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
