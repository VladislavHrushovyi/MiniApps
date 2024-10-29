using MiniShop.Domain.Models;
using Minishop.Persistence.Context;

namespace Minishop.Persistence.Repositories;

public class ProductRepository(PostgreSqlContext context) : BaseRepository<Product>(context)
{
    
}