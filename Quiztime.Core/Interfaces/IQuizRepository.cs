using Quiztime.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Quiztime.Core.Interfaces
{
    public interface IQuizRepository : IRepository<Quiz>
    {
        public Task<List<Quiz>> GetAllQuizzesAsync(Expression<Func<Quiz, bool>> filter = null);
        public Task<Quiz> GetQuizByPasswordAsync(string password, params string[] includes);
    }
}
