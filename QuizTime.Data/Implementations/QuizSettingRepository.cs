using Quiztime.Core.Entities;
using Quiztime.Core.Interfaces;
using QuizTime.Data.DAL;

namespace QuizTime.Data.Implementations
{
    public class QuizSettingRepository : Repository<QuizSetting>, IQuizSettingRepository
    {
        private AppDbContext _context;

        public QuizSettingRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
