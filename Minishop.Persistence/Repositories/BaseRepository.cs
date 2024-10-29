using System.Linq.Expressions;
using MiniShop.Application.Repository;
using MiniShop.Domain.Common;
using Minishop.Persistence.Context;

namespace Minishop.Persistence.Repositories;

public abstract class BaseRepository<TEntity>(PostgreSqlContext context) : IBaseRepository<TEntity> where TEntity : BaseModel
{
    public Task<IEnumerable<TEntity>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> GetByGuid(Guid guid)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> Add(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> Update(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> Remove(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> FindByProps(Expression<Func<TEntity, bool>> predicate)
    {
        throw new NotImplementedException();
    }
}