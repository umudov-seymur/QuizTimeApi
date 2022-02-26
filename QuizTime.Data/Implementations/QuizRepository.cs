using Quiztime.Core.Entities;
using Quiztime.Core.Interfaces;
using QuizTime.Data.DAL;

namespace QuizTime.Data.Implementations
{
    public class QuizRepository : Repository<Quiz>, IQuizRepository
    {
        private AppDbContext _context;
        public QuizRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
