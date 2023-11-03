using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WeatherFinder.Domain.Models;

namespace WeatherFinder.Persistence.Repository.Abstractions
{
    public interface IRepositoryBase<T> 
    {
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> condition, bool trackChanges);
        Task<IEnumerable<T>> FindAll(bool trackChanges);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
