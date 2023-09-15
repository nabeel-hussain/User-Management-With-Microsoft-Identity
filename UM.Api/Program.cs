//using UM.Api.Configurations.Security;
using UM.Api.Configurations.Security;
using UM.Api.CustomMiddlewares;
using UM.Application;
using UM.Domain.Entities;
using UM.Domain.Interfaces;
using UM.Infrastructure;
using UM.Infrastructure.Authentication;
using UM.Infrastructure.Database;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Security.Principal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<HMSDbContext>(dbContextOptionBuilder =>
{
    var connectingString = builder.Configuration.GetConnectionString("DefaultConnection");
    dbContextOptionBuilder.UseSqlServer(connectingString);
});
//Adding swagger and configuration for Token Button
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "UM.Api", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization Header Using Bearer Scheme."
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference= new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{ }
        }
    });
});
builder.Services.AddApplication();
builder.Services.AddRepositories();
var identityBuilder = builder.Services.AddIdentity<User, Role>(o =>
{
    // configure identity options
    o.Password.RequireDigit = false;
    o.Password.RequireLowercase = false;
    o.Password.RequireUppercase = false;
    o.Password.RequireNonAlphanumeric = false;
    o.Password.RequiredLength = 6;
    o.SignIn.RequireConfirmedEmail = false;
    o.User.RequireUniqueEmail = true;
});

identityBuilder = new IdentityBuilder(identityBuilder.UserType, identityBuilder.RoleType, identityBuilder.Services);
identityBuilder.AddEntityFrameworkStores<HMSDbContext>().AddDefaultTokenProviders();
builder.Services.AddHttpContextAccessor();
//JWT Configuration
builder.Services.ConfigureOptions<JwtOptionsSetup>();
builder.Services.ConfigureOptions<JwtBearerOptionsSetup>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
 .AddJwtBearer();
builder.Services.AddAuthorization();
//Permissions Policy COnfiguration
builder.Services.AddSingleton<IAuthorizationHandler, PermissionAuthorizationHandler>();
builder.Services.AddSingleton<IAuthorizationPolicyProvider, PermissionAuthorizationPolicyProvider>();
builder.Services.AddTransient<IPrincipal>((x) => GetCurrentPrincipalFromHttpContext(x));

var app = builder.Build();
var scope = app.Services.CreateScope();
var dataSeedService = scope.ServiceProvider.GetService<IDataSeed>();
if (dataSeedService != null)
    await dataSeedService.SecurityDataSeed();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ErrorHandlerMiddleware>(app.Environment);
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
IPrincipal GetCurrentPrincipalFromHttpContext(IServiceProvider services)
{
    using (var serviceScope = services.CreateScope())
    {
        var httpContext = serviceScope.ServiceProvider.GetService<IHttpContextAccessor>();
        if (httpContext.HttpContext == null || httpContext.HttpContext.User.Claims.Count() == 0)
            return null;
        return httpContext.HttpContext.User;
    }
}
