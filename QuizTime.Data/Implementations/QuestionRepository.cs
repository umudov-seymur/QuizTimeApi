using Quiztime.Core.Entities;
using Quiztime.Core.Interfaces;
using QuizTime.Data.DAL;

namespace QuizTime.Data.Implementations
{
    public class QuestionRepository : Repository<Question>, IQuestionRepository
    {
        private AppDbContext _context;
        public QuestionRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
