using MiniShop.Domain.Models;
using Minishop.Persistence.Context;

namespace Minishop.Persistence.Repositories;

public class UserRepository(PostgreSqlContext context) : BaseRepository<User>(context)
{
    
}