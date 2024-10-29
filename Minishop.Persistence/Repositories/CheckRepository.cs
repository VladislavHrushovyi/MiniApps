using MiniShop.Domain.Models;
using Minishop.Persistence.Context;

namespace Minishop.Persistence.Repositories;

public class CheckRepository(PostgreSqlContext context) : BaseRepository<Check>(context)
{
    
}