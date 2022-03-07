using Quiztime.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quiztime.Core.Interfaces
{
    public interface IQuizRepository : IRepository<Quiz>
    {
        public Task<List<Quiz>> GetAllQuizzesAsync();
    }
}
