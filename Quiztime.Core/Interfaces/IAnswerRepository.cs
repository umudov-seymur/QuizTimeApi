using Quiztime.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quiztime.Core.Interfaces
{
    public interface IAnswerRepository : IRepository<Answer>
    {
        Task AddRangeAsync(List<Answer> answers);
    }
}
