using BooksManagementSystem.Infrastructure.Context;
using BooksManagementSystem.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BooksManagementSystem.Infrastructure.Repositories
{
    public class GenericRepository<T>(ApplicationDbContext context) : IGenericRepository<T> where T : class
    {
        public virtual IQueryable<T> GetAllNoTracking() => context.Set<T>().AsNoTracking().AsQueryable();
        public virtual IQueryable<T> GetAllWithTracking() => context.Set<T>().AsQueryable();
        public virtual async Task<bool> IsExistAsync(Expression<Func<T, bool>> match) => await context.Set<T>().AnyAsync(match);
        public virtual async Task<T> GetByIdAsync(int id) => (await context.Set<T>().FindAsync(id))!;
        public virtual async Task AddAsync(T entity) => await context.Set<T>().AddAsync(entity);
        public virtual async Task AddRangeAsync(IEnumerable<T> entities) => await context.Set<T>().AddRangeAsync(entities);

        public virtual void Update(T entity) => context.Set<T>().Update(entity);

        public virtual void UpdateRange(IEnumerable<T> entities) => context.Set<T>().UpdateRange(entities);

        public virtual void Delete(T entity) => context.Set<T>().Remove(entity);
        public virtual void DeleteRange(IEnumerable<T> entities) => context.Set<T>().RemoveRange(entities);

    }
}
