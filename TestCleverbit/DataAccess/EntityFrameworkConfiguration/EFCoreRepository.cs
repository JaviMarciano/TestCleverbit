using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestCleverbit.Domain.Repositories;

namespace TestCleverbit.DataAccess.EntityFrameworkConfiguration
{
    public abstract class EFCoreRepository<TDbContext, TKey, TEntity> : ICrudRepository<TKey, TEntity>
         where TDbContext : DbContext
         where TEntity : class, new()
    {
        private readonly Action<TEntity, TKey> _keySetter;

        public EFCoreRepository(TDbContext dbContext)
        {
            DbContext = dbContext;
            _keySetter = KeyProperty.GetSetter();
        }

        public abstract Expression<Func<TEntity, TKey>> KeyProperty { get; }

        protected TDbContext DbContext { get; }

        public virtual Task<TEntity> GetAsync(TKey key)
        {
            return DbContext.Set<TEntity>().AsNoTracking().SingleAsync(KeyProperty.GetEqualsPredicateForConstant(key));
        }

        public virtual Task<TEntity> TryGetAsync(TKey key)
        {
            return DbContext.Set<TEntity>().AsNoTracking().SingleOrDefaultAsync(KeyProperty.GetEqualsPredicateForConstant(key));
        }

        public virtual async Task<IList<TEntity>> GetAllAsync()
        {
            return await DbContext.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            OnAdding(entity);
            DbContext.Set<TEntity>().Add(entity);
            await DbContext.SaveChangesAsync();
            DbContext.Entry(entity).State = EntityState.Detached;
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            DbContext.Set<TEntity>().Attach(entity);
            OnUpdating(entity);
            DbContext.Set<TEntity>().Update(entity);
            await SaveChangesAndDetachAsync(entity);
        }

        public virtual Task UpdateAsync<TProperty>(TKey key, Expression<Func<TEntity, TProperty>> propertyExpression, TProperty value)
        {
            var entity = new TEntity();
            _keySetter(entity, key);
            return UpdateAsync(entity, propertyExpression, value);
        }

        public virtual async Task UpdateAsync<TProperty>(TEntity entity, Expression<Func<TEntity, TProperty>> propertyExpression, TProperty value)
        {
            var entityEntry = DbContext.Set<TEntity>().Attach(entity);
            propertyExpression.GetSetter()(entity, value);
            entityEntry.Property(propertyExpression).IsModified = true;
            OnUpdating(entity, entityEntry);
            await SaveChangesAndDetachAsync(entity);
        }

        public virtual async Task UpdateRangeAsync(IEnumerable<TEntity> entities)
        {
            DbContext.Set<TEntity>().AttachRange(entities);
            foreach (var entity in entities)
            {
                OnUpdating(entity);
            }
            DbContext.Set<TEntity>().UpdateRange(entities);
            await SaveChangesAndDetachAsync(entities);
        }

        public virtual Task RemoveAsync(TKey key)
        {
            var entity = new TEntity();
            _keySetter(entity, key);
            return RemoveAsync(entity);
        }

        public virtual async Task RemoveAsync(TEntity entity)
        {
            DbContext.Set<TEntity>().Remove(entity);
            await SaveChangesAndDetachAsync(entity);
        }

        protected virtual async Task SaveChangesAndDetachAsync(TEntity entity)
        {
            try
            {
                await DbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw UpdateConcurrencyException.From(ex);
            }
            finally
            {
                DbContext.Entry(entity).State = EntityState.Detached;
            }
        }

        protected virtual async Task SaveChangesAndDetachAsync(IEnumerable<TEntity> entities)
        {
            try
            {
                await DbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw UpdateConcurrencyException.From(ex);
            }
            finally
            {
                foreach (var entity in entities)
                {
                    DbContext.Entry(entity).State = EntityState.Detached;
                }
            }
        }

        protected virtual async Task SaveUpdateChangesAsync(TEntity entity)
        {
            try
            {
                await DbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw UpdateConcurrencyException.From(ex);
            }

            DbContext.Entry(entity).State = EntityState.Detached;
        }

        protected virtual void OnAdding(TEntity entity) { }
        protected virtual void OnUpdating(TEntity entity) { }
        protected virtual void OnUpdating(TEntity entity, EntityEntry<TEntity> entityEntry) { }
    }
}
