using System.Linq.Expressions;
using MiniShop.Domain.Common;

namespace MiniShop.Application.Repository;

public interface IBaseRepository<TEntity> where TEntity : BaseModel
{
    Task<IEnumerable<TEntity>> GetAll();
    Task<TEntity> GetByGuid(Guid guid);
    Task<TEntity> Add(TEntity entity);
    Task<TEntity> Update(TEntity entity);
    Task<TEntity> Remove(TEntity entity);
    Task<TEntity> FindByProps(Expression<Func<TEntity, bool>> predicate);
}