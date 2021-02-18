using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JobListing.Services.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> FindAll();
        Task<IEnumerable<T>> FindByCondition(Expression<Func<T, bool>> expression);
        void Create(T entity);
        Task<int> Update(T entity);
        Task<int> Delete(T entity);
        Task<int> Save(T entity);
        Task<int> Commit();
        Task<T> GetBy(Expression<Func<T, bool>> expression);
    }
}
