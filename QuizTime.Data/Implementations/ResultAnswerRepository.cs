using Quiztime.Core.Entities;
using Quiztime.Core.Interfaces;
using QuizTime.Data.DAL;

namespace QuizTime.Data.Implementations
{
    public class ResultAnswerRepository : Repository<ResultAnswer>, IResultAnswerRepository
    {
        private AppDbContext _context;
        public ResultAnswerRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
