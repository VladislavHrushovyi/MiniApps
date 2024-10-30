using System.Linq.Expressions;
using MiniShop.Application.Repository;
using MiniShop.Domain.Common;
using Minishop.Persistence.Context;

namespace Minishop.Persistence.Repositories;

public abstract class BaseRepository<TEntity>(PostgreSqlContext context) : IBaseRepository<TEntity> where TEntity : BaseModel
{
    public async Task<IEnumerable<TEntity>> GetAll()
    {
        return await Task.Run(() => context.Set<TEntity>().ToList());
    }

    public async Task<TEntity?> GetByGuid(Guid guid)
    {
        return await Task.Run(() => context.Set<TEntity>().FirstOrDefault(x => x.Id == guid));
    }

    public async Task<TEntity> Add(TEntity entity)
    {
        return (await context.Set<TEntity>().AddAsync(entity)).Entity;
    }

    public async Task<TEntity> Update(TEntity entity)
    {
        return await Task.Run(() => context.Set<TEntity>().Update(entity).Entity);
    }

    public Task<TEntity> Remove(TEntity entity)
    {
        return Task.Run(() => context.Set<TEntity>().Remove(entity).Entity);
    }

    public Task<TEntity?> FindByProps(Expression<Func<TEntity, bool>> predicate)
    {
        return Task.Run(() => context.Set<TEntity>().FirstOrDefault(predicate));
    }
}