using Microsoft.Extensions.DependencyInjection;
using MiniShop.Application.Repository;
using Minishop.Persistence.Repositories;

namespace Minishop.Persistence;

public static class PersistenceServiceExtension
{
    public static void AddPersistenceServices(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICheckRepository, CheckRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IUserRoleRepository, UserRoleRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
    }
}