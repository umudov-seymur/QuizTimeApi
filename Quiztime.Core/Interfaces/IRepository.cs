using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Quiztime.Core.Interfaces
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, params string[] includes);
        Task<T> GetAsync(Expression<Func<T, bool>> filter = null, params string[] includes);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<int> GetTotalCountAsync(Expression<Func<T, bool>> filter = null);
        Task<bool> IsExistAsync(Expression<Func<T, bool>> filter);
    }
}
