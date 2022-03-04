using Quiztime.Core.Entities;
using Quiztime.Core.Interfaces;
using QuizTime.Data.DAL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuizTime.Data.Implementations
{
    public class AnswerRepository : Repository<Answer>, IAnswerRepository
    {
        private AppDbContext _context;
        public AnswerRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddRangeAsync(List<Answer> answers)
        {
            await _context.Set<Answer>().AddRangeAsync(answers);
        }
    }
}
