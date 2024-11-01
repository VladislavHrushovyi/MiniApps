using MiniShop.Application.Repository;
using MiniShop.Domain.Models;
using Minishop.Persistence.Context;

namespace Minishop.Persistence.Repositories;

public class RoleRepository(PostgreSqlContext context) : BaseRepository<Role>(context), IRoleRepository
{
    
}