using Microsoft.EntityFrameworkCore;
using MiniShop.Domain.Models;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace Minishop.Persistence.Context;

public class PostgreSqlContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Check> Checks { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<Role> Roles { get; set; }
    
    public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options) : base(options)
    {
        
    }
}