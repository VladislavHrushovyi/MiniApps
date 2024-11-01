using MiniShop.Application.Repository;
using MiniShop.Domain.Models;
using Minishop.Persistence.Context;

namespace Minishop.Persistence.Repositories;

public class UserRoleRepository(PostgreSqlContext context) : BaseRepository<UserRole>(context), IUserRoleRepository
{
    
}