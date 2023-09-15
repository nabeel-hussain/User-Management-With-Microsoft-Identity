using UM.Domain.Interfaces;
using UM.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using UM.Infrastructure.DataSeed;
using UM.Domain.Interfaces.Authentication;
using UM.Infrastructure.Authentication;

namespace UM.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUser, UserRepository>();
        services.AddScoped<IRole,RoleRepository>();
        services.AddTransient<IDataSeed,HMSDataSeed >();
        services.AddScoped<IJwtTokenManager, JwtTokenManager>();
        services.AddScoped<IPermission, PermissionRepository>();
        return services;
    }
}
