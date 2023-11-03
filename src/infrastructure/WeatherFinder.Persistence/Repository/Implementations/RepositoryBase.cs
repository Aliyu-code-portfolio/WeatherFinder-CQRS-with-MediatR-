using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WeatherFinder.Persistence.Data;
using WeatherFinder.Persistence.Repository.Abstractions;

namespace WeatherFinder.Persistence.Repository.Implementations
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        public readonly DbSet<T> dbSet;

        public RepositoryBase(RepositoryContext repositoryContext)
        {
            dbSet = repositoryContext.Set<T>();
        }

        public void Create(T entity)
        {
            dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public async Task<IEnumerable<T>> FindAll(bool trackChanges)
        {
            return  trackChanges? await dbSet.ToListAsync() : await dbSet.AsNoTracking().ToListAsync();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> condition, bool trackChanges)
        {
            return trackChanges ?  dbSet.Where(condition)
                :  dbSet.Where(condition).AsNoTracking();
        }

        public void Update(T entity)
        {
            dbSet.Update(entity);
        }
    }
}
