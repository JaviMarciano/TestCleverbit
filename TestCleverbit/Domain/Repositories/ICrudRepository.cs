using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TestCleverbit.Domain.Repositories
{
    public interface IBasicRepository<TKey, TEntity> where TEntity : class, new()
    {
        Task<TEntity> GetAsync(TKey key);
        Task<TEntity> TryGetAsync(TKey key);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task RemoveAsync(TKey key);
    }

    public interface ICrudRepository<TKey, TEntity> : IBasicRepository<TKey, TEntity> where TEntity : class, new()
    {
        Task<IList<TEntity>> GetAllAsync();
        Task UpdateAsync<TProperty>(TKey key, Expression<Func<TEntity, TProperty>> propertyExpression, TProperty value);
        Task UpdateAsync<TProperty>(TEntity entity, Expression<Func<TEntity, TProperty>> propertyExpression, TProperty value);
        Task UpdateRangeAsync(IEnumerable<TEntity> entities);
        Task RemoveAsync(TEntity entity);
    }
}
