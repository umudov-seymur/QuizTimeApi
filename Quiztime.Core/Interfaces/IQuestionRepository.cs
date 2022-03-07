using Quiztime.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quiztime.Core.Interfaces
{
    public interface IQuestionRepository : IRepository<Question>
    {
        public Task<List<Question>> GetAllQuestionsByQuizIdAsync(Guid quizId);
    }
}
