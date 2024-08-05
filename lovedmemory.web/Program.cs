using lovedmemory.infrastructure.Security.AuthorizationFilters;
using lovedmemory.infrastructure.Security.CurrentUserProvider;
using lovedmemory.web.Services;
using Microsoft.OpenApi.Models;
using schoolapp.Infrastructure;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    //.Enrich.With
    .Enrich.FromLogContext() //logging from DiagnosticContext
    .Enrich.WithProperty("ApplicationName", "Billing_web_api")
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .WriteTo.Seq("http://localhost:5341")
    .WriteTo.File($"{builder.Environment.ContentRootPath}/Logs/webapi_.txt",
    LogEventLevel.Information,
    "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}{NewLine}",
    rollingInterval: RollingInterval.Day)
    .CreateLogger();
builder.WebHost.ConfigureKestrel(opts =>
{
    opts.ListenAnyIP(5000); 

});
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddHttpContextAccessor();

// Add services to the container.
//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

builder.Services.AddControllers(options =>
{
    options.Filters.Add<AuthorizationFilter>();
});
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
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors(options => options
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
