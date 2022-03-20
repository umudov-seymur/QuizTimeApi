using Quiztime.Core.Entities;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Quiztime.Core.Interfaces
{
    public interface IResultRepository : IRepository<Result>
    {
        public Task<Result> GetLastResultAsync(Expression<Func<Result, bool>> filter = null);
    }
}
