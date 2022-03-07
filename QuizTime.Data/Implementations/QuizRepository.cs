using Microsoft.EntityFrameworkCore;
using Quiztime.Core.Entities;
using Quiztime.Core.Interfaces;
using QuizTime.Data.DAL;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizTime.Data.Implementations
{
    public class QuizRepository : Repository<Quiz>, IQuizRepository
    {
        private AppDbContext _context;
        public QuizRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Quiz>> GetAllQuizzesAsync()
        {
            return await _context.Quizzes
                .Include(n => n.Password)
                .Include(n => n.Category)
                .OrderByDescending(n => n.CreatedAt)
                .ToListAsync();
        }
    }
}
