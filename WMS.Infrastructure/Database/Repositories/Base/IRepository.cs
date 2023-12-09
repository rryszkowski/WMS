using System.Linq.Expressions;
using WMS.Domain.Base;

namespace WMS.Infrastructure.Database.Repositories.Base;

public interface IRepository<TEntity> where TEntity : BaseEntity
{
    ValueTask<TEntity> GetAsync(Guid id);
    Task<List<TEntity>> GetAllAsync();
    IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

    Task AddAsync(TEntity entity);
    Task AddRangeAsync(IEnumerable<TEntity> entities);

    void Remove(TEntity entity);
    void RemoveRange(IEnumerable<TEntity> entities);
}