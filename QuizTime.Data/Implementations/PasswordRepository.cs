using Quiztime.Core.Entities;
using Quiztime.Core.Interfaces;
using QuizTime.Data.DAL;

namespace QuizTime.Data.Implementations
{
    public class PasswordRepository : Repository<Password>, IPasswordRepository
    {
        private AppDbContext _context;

        public PasswordRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
